namespace CoreLibrary.Wpf.ViewModel
{
    using System.Windows.Media.Imaging;

    public class BaseUserViewModel : BaseViewModel
    {
        private string _name;
        private BitmapImage _photo;
        private string _userPrincipalName;

        public BaseUserViewModel()
        {
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public BitmapImage Photo
        {
            get => _photo;
            set => Set(ref _photo, value);
        }

        public string UserPrincipalName
        {
            get => _userPrincipalName;
            set => Set(ref _userPrincipalName, value);
        }
    }
}