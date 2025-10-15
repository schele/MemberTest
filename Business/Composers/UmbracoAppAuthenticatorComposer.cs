using MembersTestUmbraco16.Business.Providers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Web;

namespace MembersTestUmbraco16.Business.Composers
{
	public class UmbracoAppAuthenticatorComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			var identityBuilder = new MemberIdentityBuilder(builder.Services);
			identityBuilder.AddTwoFactorProvider<UmbracoAppAuthenticator>(UmbracoAppAuthenticator.Name);

            builder.Services.AddSingleton<IPublishedMemberCache>(factory =>
            {
                var umbracoContextFactory = factory.GetRequiredService<IUmbracoContextFactory>();
                return umbracoContextFactory.EnsureUmbracoContext().UmbracoContext.PublishedSnapshot.Members;
            });
        }
	}
}