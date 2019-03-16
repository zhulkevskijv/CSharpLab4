using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab03.Models;
using Lab03.Tools;
using Lab03.Tools.Exceptions;
using Lab03.Tools.Managers;
using Lab03.Tools.Navigation;

namespace Lab03.ViewModels
{
    internal class PersonInputViewModel : BaseViewModel
    {
        #region Fields

        private readonly Person _person;

        public PersonInputViewModel()
        {
            _person = new Person("", "", "");
            StationManager.CurrentPerson = _person;
        }

        #region Commands

        private RelayCommand<object> _proceedCommand;

        #endregion

        #endregion

        #region Properties

        public Person PersonUser 
        {
            get => _person;
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??
                       (_proceedCommand = new RelayCommand<object>(ProceedImplementation, o => CanExecuteCommand()));
            }
        }

        #endregion

        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(PersonUser.Surname)&&!string.IsNullOrWhiteSpace(PersonUser.Name)&& !string.IsNullOrWhiteSpace(PersonUser.Email);
        }

        private async void ProceedImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool proceedToResults = await Task.Run(() =>
            {
                StationManager.CurrentPerson = _person;
                try
                {
                    StationManager.CurrentPerson.CheckInput();
                }
                catch (PersonTooOldException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (PersonNotBornException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (EmailNotValidException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                Thread.Sleep(1000);
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (proceedToResults)
                NavigationManager.Instance.Navigate(ViewType.Result);
        }
    }
}