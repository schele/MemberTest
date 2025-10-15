using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MembersTestUmbraco16.Models.ViewModels
{
	public class LoginViewModel : PageViewModel<Login>
	{
		public LoginViewModel(Login content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
		{
		}

		public string Username { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public string? ErrorMessage { get; set; } = string.Empty;
	}
}