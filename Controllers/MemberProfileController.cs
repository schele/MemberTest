using MembersTestUmbraco16.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Controllers
{
	public class MemberProfileController : RenderController
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public MemberProfileController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public override IActionResult Index()
		{
			if (CurrentPage is MemberProfile memberProfile)
			{
				var model = new MemberProfileViewModel(memberProfile, _umbracoContextAccessor);

                // Access TempData
                //if (TempData["is2faEnabled"] != null)
                //{
                //    var is2faEnabled = TempData["is2faEnabled"];
                //}


                return CurrentTemplate(model);
			}

			return null;	
		}
	}
}