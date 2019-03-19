using System;
using Lab4.Models;
using Lab4.Tools;
using Lab4.Tools.Managers;
using Lab4.Tools.Navigation;

namespace Lab4.ViewModels
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
