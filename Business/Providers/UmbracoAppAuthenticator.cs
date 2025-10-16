using Google.Authenticator;
using System.Runtime.Serialization;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;

namespace MembersTestUmbraco16.Business.Providers
{
    [DataContract]
    public class QrCodeSetupData : ISetupTwoFactorModel
    {
        public string? Secret { get; init; }

        public SetupCode? SetupCode { get; init; }
    }

    public class UmbracoAppAuthenticator : ITwoFactorProvider
    {
        public const string Name = "2FA Member";
        private readonly IMemberService _memberService;

        public UmbracoAppAuthenticator(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public string ProviderName => Name;

        public Task<ISetupTwoFactorModel> GetSetupDataAsync(Guid userOrMemberKey, string secret)
        {
            var member = _memberService.GetByKey(userOrMemberKey);
            var applicationName = "2FA Member";
            var twoFactorAuthenticator = new TwoFactorAuthenticator();
            var setupInfo = twoFactorAuthenticator.GenerateSetupCode(applicationName, member.Username, secret, false);
            
            return Task.FromResult<ISetupTwoFactorModel>(new QrCodeSetupData()
            {
                SetupCode = setupInfo,
                Secret = secret
            });
        }

        public bool ValidateTwoFactorPIN(string secret, string code)
        {
            var twoFactorAuthenticator = new TwoFactorAuthenticator();

            return twoFactorAuthenticator.ValidateTwoFactorPIN(secret, code);
        }

        public bool ValidateTwoFactorSetup(string secret, string token) => ValidateTwoFactorPIN(secret, token);
    }
}