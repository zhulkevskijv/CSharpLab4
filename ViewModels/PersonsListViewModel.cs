using System.Collections.ObjectModel;
using Lab4.Models;
using Lab4.Tools;
using Lab4.Tools.Managers;

namespace Lab4.ViewModels
{
    class PersonsListViewModel : BaseViewModel
    {
        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        internal PersonsListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
        }

    }
}
