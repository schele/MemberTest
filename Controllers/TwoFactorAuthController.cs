using MembersTestUmbraco16.Models.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Controllers
{
	public class TwoFactorAuthController : RenderController
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public TwoFactorAuthController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public override IActionResult Index()
		{
			var url = HttpContext.Request.GetEncodedUrl;

            if (CurrentPage is TwoFactorAuth memberProfile)
			{
				var model = new TwoFactorAuthViewModel(memberProfile, _umbracoContextAccessor);

                // Access TempData
                if (TempData["is2faEnabled"] != null)
                {
                    model.Is2faEnabled = Convert.ToBoolean(TempData["is2faEnabled"]);
					model.MemberKey = TempData["memberKey"].ToString();
					model.ReturnUrl = TempData["returnUrl"].ToString();
                }

                return CurrentTemplate(model);
			}

			return null;	
		}
	}
}