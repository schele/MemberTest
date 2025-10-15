using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Models.ViewModels
{
	public class StartViewModel : PageViewModel<Start>
	{
		public StartViewModel(Start content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
		{
		}
	}
}