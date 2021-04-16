namespace CoreLibrary.Wpf.Contracts.Services
{
    public interface IIdentityCacheService
    {
        byte[] ReadMsalToken();

        void SaveMsalToken(byte[] token);
    }
}