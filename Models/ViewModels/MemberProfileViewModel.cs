using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Models.ViewModels
{
	public class MemberProfileViewModel : PageViewModel<MemberProfile>
	{
		public MemberProfileViewModel(MemberProfile content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
		{
		}
	}
}