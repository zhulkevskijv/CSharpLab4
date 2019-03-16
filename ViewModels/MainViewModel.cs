using System.Windows;
using Lab03.Tools;

namespace Lab03.ViewModels
{
    internal class MainViewModel : BaseViewModel, ILoaderOwner
    {
        #region Fields

        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        #endregion

        #region Properties

        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        internal MainViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}