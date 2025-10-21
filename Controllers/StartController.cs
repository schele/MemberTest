using MembersTestUmbraco16.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Controllers
{
	public class StartController : RenderController
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public StartController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public override IActionResult Index()
		{
			if (CurrentPage is Start start)
			{
				var model = new StartViewModel(start, _umbracoContextAccessor);

				return CurrentTemplate(model);
			}

			return null;	
		}
	}
}