using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab4.Models;
using Lab4.Tools;
using Lab4.Tools.Exceptions;
using Lab4.Tools.Managers;
using Lab4.Tools.Navigation;

namespace Lab4.ViewModels
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

        private RelayCommand<object> _addCommand;

        #endregion

        #endregion

        #region Properties

        public Person PersonUser 
        {
            get => _person;
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addCommand ??
                       (_addCommand = new RelayCommand<object>(AddImplementation, o => CanExecuteCommand()));
            }
        }

        #endregion

        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(PersonUser.Surname)&&!string.IsNullOrWhiteSpace(PersonUser.Name)&& !string.IsNullOrWhiteSpace(PersonUser.Email);
        }

        private async void AddImplementation(object obj)
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
                StationManager.DataStorage.AddPerson(_person);
                return true;
               
            });
            LoaderManager.Instance.HideLoader();
            if (proceedToResults)
                NavigationManager.Instance.Navigate(ViewType.PersonsList);
            
        }
    }
}