using MembersTestUmbraco16.Business.Providers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Security;

namespace MembersTestUmbraco16.Business.Composers
{
    public class UmbracoUserAppAuthenticatorComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            var identityBuilder = new BackOfficeIdentityBuilder(builder.Services);

            identityBuilder.AddTwoFactorProvider<UmbracoUserAppAuthenticator>(UmbracoUserAppAuthenticator.Name);
        }
    }
}