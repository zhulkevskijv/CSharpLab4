using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab03.Models;
using Lab03.Tools;

namespace Lab03.ViewModels
{
    internal class PersonInputViewModel : BaseViewModel
    {
        #region Fields

        private Person _person;

        #region Commands

        private RelayCommand<object> _submitDateCommand;

        #endregion

        #endregion

        #region Properties

        public Person PersonUser 
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> ProceedDateCommand
        {
            get
            {
                return _submitDateCommand ??
                       (_submitDateCommand = new RelayCommand<object>(ProceedImplementation, o => CanExecuteCommand()));
            }
        }

        #endregion

        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace();
        }

        private async void ProceedImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });
            LoaderManager.Instance.HideLoader();
            int age = CalculateAge();
            if (age > 135)
            {
                ShowErrorMessageBox("You're too old to be alive.");
                return;
            }

            if (age < 0)
            {
                ShowErrorMessageBox("You aren't born yet");
                return;
            }
            Age = age + "";
            
        }

        #region AdditionalMethodsForCalculating

        private void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message);
        }
        #endregion


    }
}