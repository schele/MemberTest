using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Models.ViewModels
{
	public class TwoFactorAuthViewModel : PageViewModel<TwoFactorAuth>
	{
		public TwoFactorAuthViewModel(TwoFactorAuth content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
		{
		}

        public bool Is2faEnabled { get; set; }

        public string? MemberKey { get; set; }

        public string? ReturnUrl { get; set; }
    }
}