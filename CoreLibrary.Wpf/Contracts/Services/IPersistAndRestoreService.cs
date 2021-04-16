namespace CoreLibrary.Wpf.Contracts.Services
{
    public interface IPersistAndRestoreService
    {
        void PersistData();

        void RestoreData();
    }
}