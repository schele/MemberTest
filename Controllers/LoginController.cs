using MembersTestUmbraco16.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Controllers
{
	public class LoginController : RenderController
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public LoginController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public override IActionResult Index()
		{
			if (CurrentPage is Login login)
			{
				var model = new LoginViewModel(login, _umbracoContextAccessor);

				return CurrentTemplate(model);
			}

			return null;	
		}
	}
}