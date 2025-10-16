using MembersTestUmbraco16.Business.Providers;
using Microsoft.AspNetCore.Identity;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Security;

namespace MembersTestUmbraco16.Business.Composers
{
	public class UmbracoAppAuthenticatorComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			var identityBuilder = new MemberIdentityBuilder(builder.Services);

			identityBuilder.AddTwoFactorProvider<UmbracoAppAuthenticator>(UmbracoAppAuthenticator.Name);
        }
	}
}