using Google.Authenticator;
using System.Runtime.Serialization;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;

namespace MembersTestUmbraco16.Business.Providers
{
	[DataContract]
	public class QrCodeSetupData : ISetupTwoFactorModel
	{
		/// <summary>
		/// The secret unique code for the user and this ITwoFactorProvider.
		/// </summary>
		public string? Secret { get; init; }

		/// <summary>
		/// The SetupCode from the GoogleAuthenticator code.
		/// </summary>
		public SetupCode? SetupCode { get; init; }
	}

	/// <summary>
	/// App Authenticator implementation of the ITwoFactorProvider
	/// </summary>
	public class UmbracoAppAuthenticator : ITwoFactorProvider
	{
		/// <summary>
		/// The unique name of the ITwoFactorProvider. This is saved in a constant for reusability.
		/// </summary>
		public const string Name = "UmbracoAppAuthenticator";

		private readonly IMemberService _memberService;

		/// <summary>
		/// Initializes a new instance of the <see cref="UmbracoAppAuthenticator"/> class.
		/// </summary>
		public UmbracoAppAuthenticator(IMemberService memberService)
		{
			_memberService = memberService;
		}

		/// <summary>
		/// The unique provider name of ITwoFactorProvider implementation.
		/// </summary>
		/// <remarks>
		/// This value will be saved in the database to connect the member with this  ITwoFactorProvider.
		/// </remarks>
		public string ProviderName => Name;

		/// <summary>
		/// Returns the required data to setup this specific ITwoFactorProvider implementation. In this case it will contain the url to the QR-Code and the secret.
		/// </summary>
		/// <param name="userOrMemberKey">The key of the user or member</param>
		/// <param name="secret">The secret that ensures only this user can connect to the authenticator app</param>
		/// <returns>The required data to setup the authenticator app</returns>
		public Task<ISetupTwoFactorModel> GetSetupDataAsync(Guid userOrMemberKey, string secret)
		{
			var member = _memberService.GetByKey(userOrMemberKey);
			var applicationName = "testingOn15";
			var twoFactorAuthenticator = new TwoFactorAuthenticator();

			if (member != null)
			{
                SetupCode setupInfo = twoFactorAuthenticator.GenerateSetupCode(applicationName, member.Username, secret, false);

                return Task.FromResult<ISetupTwoFactorModel>(new QrCodeSetupData()
                {
                    SetupCode = setupInfo,
                    Secret = secret
                });
            }

			return null;
		}

		/// <summary>
		/// Validated the code and the secret of the user.
		/// </summary>
		public bool ValidateTwoFactorPIN(string secret, string code)
		{
			var twoFactorAuthenticator = new TwoFactorAuthenticator();
			return twoFactorAuthenticator.ValidateTwoFactorPIN(secret, code);
		}

		/// <summary>
		/// Validated the two factor setup
		/// </summary>
		/// <remarks>Called to confirm the setup of two factor on the user. In this case we confirm in the same way as we login by validating the PIN.</remarks>
		public bool ValidateTwoFactorSetup(string secret, string token) => ValidateTwoFactorPIN(secret, token);
	}
}