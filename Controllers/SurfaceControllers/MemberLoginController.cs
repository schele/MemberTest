using MembersTestUmbraco16.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
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

		public MemberLoginController(IMemberSignInManager memberSignInManager, IMemberManager memberManager, IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
		{
			_memberSignInManager = memberSignInManager;
			_memberManager = memberManager;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MemberLogin(LoginModel model)
		{
			var member = await _memberManager.FindByNameAsync(model.Username);

			if (member != null)
			{
				var status = await _memberManager.CheckPasswordAsync(member, model.Password);

				if (status)
				{
					await _memberSignInManager.SignInAsync(member, isPersistent: true);
										
					return Redirect("/memberprofile");
				}
			}

			TempData["LoginError"] = "Invalid login credentials";

			return RedirectToCurrentUmbracoPage();
		}
	}
}