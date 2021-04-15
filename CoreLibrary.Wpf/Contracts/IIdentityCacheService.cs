namespace CoreLibrary.Wpf.Contracts
{
    public interface IIdentityCacheService
    {
        byte[] ReadMsalToken();

        void SaveMsalToken(byte[] token);
    }
}