namespace CoreLibrary.Wpf.Contracts
{
    using CoreLibrary.Enums;

    using System;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        event EventHandler LoggedIn;

        event EventHandler LoggedOut;

        Task<bool> AcquireTokenSilentAsync();

        Task<string> GetAccessTokenAsync(string[] scopes);

        Task<string> GetAccessTokenForGraphAsync();

        string GetAccountUserName();

        void InitializeWithAadAndPersonalMsAccounts(string clientId, string redirectUri = null);

        void InitializeWithAadMultipleOrgs(string clientId, bool integratedAuth = false, string redirectUri = null);

        void InitializeWithAadSingleOrg(string clientId, string tenant, bool integratedAuth = false, string redirectUri = null);

        bool IsAuthorized();

        bool IsLoggedIn();

        Task<ELoginResultType> LoginAsync();

        Task LogoutAsync();
    }
}