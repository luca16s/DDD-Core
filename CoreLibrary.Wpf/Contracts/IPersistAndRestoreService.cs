namespace CoreLibrary.Wpf.Contracts
{
    public interface IPersistAndRestoreService
    {
        void RestoreData();

        void PersistData();
    }
}