namespace CoreLibrary.Wpf.Contracts.Services
{
    using CoreLibrary.Models;

    using System.Threading.Tasks;

    public interface IMicrosoftGraphService
    {
        Task<UserModel> GetUserInfoAsync(string accessToken);

        Task<string> GetUserPhoto(string accessToken);
    }
}