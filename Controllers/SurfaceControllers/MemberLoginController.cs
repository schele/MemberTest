using MembersTestUmbraco16.Business.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Models;
using Umbraco.Cms.Web.Common.Security;
using Umbraco.Cms.Web.Website.Controllers;

namespace MembersTestUmbraco16.Controllers.SurfaceControllers
{
	public class MemberLoginController : SurfaceController
	{
		private readonly IMemberSignInManager _memberSignInManager;
		private readonly IMemberManager _memberManager;
        private readonly ILogger<MemberLoginController> _logger;
        private readonly ITwoFactorLoginService _twoFactorLoginService;

        public MemberLoginController(ILogger<MemberLoginController> logger, ITwoFactorLoginService twoFactorLoginService, IMemberSignInManager memberSignInManager, IMemberManager memberManager, IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
		{
            _logger = logger;
            _twoFactorLoginService = twoFactorLoginService;
            _memberSignInManager = memberSignInManager;
			_memberManager = memberManager;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MemberLogin(LoginModel model, string? returnUrl = null)
		{
            var member = await _memberManager.FindByNameAsync(model.Username);

			if (member != null)
			{
				var status = await _memberManager.CheckPasswordAsync(member, model.Password);

				if (status)
				{
                    var is2faEnabled = await _memberManager.GetTwoFactorEnabledAsync(member);

                    TempData["is2faEnabled"] = is2faEnabled;
                    TempData["memberKey"] = member.Key;

                    return Redirect("/twofactorauth");
                }
			}

			return RedirectToCurrentUmbracoPage();
		}

        [HttpPost]
        public async Task<IActionResult> ValidateAndSaveSetup(
        string providerName,
        string secret,
        string code,
        Guid memberKey,
        string? returnUrl = null)
        {
            var isValid = _twoFactorLoginService.ValidateTwoFactorSetup(providerName, secret, code);

            if (!isValid)
            {
                ModelState.AddModelError(nameof(code), "Invalid Code");

                TempData["memberKey"] = memberKey;
                TempData["is2faEnabled"] = false;

                return RedirectToLocal("/twofactorauth");
            }

            var twoFactorLogin = new TwoFactorLogin
            {
                Confirmed = true,
                Secret = secret,
                UserOrMemberKey = memberKey,
                ProviderName = providerName,
            };

            await _twoFactorLoginService.SaveAsync(twoFactorLogin);

            var member = await _memberManager.FindByIdAsync(memberKey.ToString());

            if (member != null)
            {
                await _memberSignInManager.SignInAsync(member, isPersistent: true);
            }

            return RedirectToLocal("/memberprofile");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Verify2FACode(Verify2FACodeModel model, Guid memberKey, string? returnUrl = null)
        {
            var member = await _memberManager.FindByIdAsync(memberKey.ToString());

            if (member == null)
            {
                _logger.LogWarning("Verify2FACode :: No verified member found, returning 404");

                return NotFound();
            }
            else
            {
                var secret = await _twoFactorLoginService.GetSecretForUserAndProviderAsync(memberKey, model.Provider);

                if (secret != null)
                {
                    var isValidCode = _twoFactorLoginService.ValidateTwoFactorSetup(model.Provider, secret, model.Code);

                    if (isValidCode)
                    {
                        await _memberSignInManager.SignInAsync(member, isPersistent: true);
                    }
                    else
                    {
                        TempData["is2faEnabled"] = true;
                        TempData["memberKey"] = member.Key;

                        return Redirect("/twofactorauth");
                    }
                }
                
                return RedirectToLocal("/memberprofile");
            }
        }

        private IActionResult RedirectToLocal(string? returnUrl) => Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : RedirectToCurrentUmbracoPage();
    }
}