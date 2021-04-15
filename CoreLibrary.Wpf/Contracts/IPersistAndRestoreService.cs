namespace CoreLibrary.Wpf.Contracts
{
    public interface IPersistAndRestoreService
    {
        void PersistData();

        void RestoreData();
    }
}