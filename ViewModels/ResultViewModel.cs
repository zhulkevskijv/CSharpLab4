using System;
using Lab03.Models;
using Lab03.Tools;
using Lab03.Tools.Managers;
using Lab03.Tools.Navigation;

namespace Lab03.ViewModels
{
    class ResultViewModel :BaseViewModel
    {
        private Person _person = StationManager.CurrentPerson;
        private RelayCommand<Object> _backCommand;
        private RelayCommand<Object> _closeCommand;

        public Person PersonUser
        {
            get { return _person; }
        }

        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.PersonInput)));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

    }
}
