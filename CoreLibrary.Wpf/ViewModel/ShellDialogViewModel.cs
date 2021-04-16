namespace CoreLibrary.Wpf.ViewModel
{
    using CoreLibrary.Wpf.Commands;

    using System;
    using System.Windows.Input;

    public class ShellDialogViewModel : BaseViewModel
    {
        private ICommand _closeCommand;

        public ShellDialogViewModel()
        {
        }

        public ICommand CloseCommand => _closeCommand ??= new RelayCommand(OnClose);

        public Action<bool?> SetResult { get; set; }

        private void OnClose()
        {
            bool result = true;
            SetResult(result);
        }
    }
}