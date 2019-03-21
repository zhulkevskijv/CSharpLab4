using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Lab4.Models;
using Lab4.Tools;
using Lab4.Tools.Managers;
using Lab4.Tools.Navigation;

namespace Lab4.ViewModels
{
    class PersonsListViewModel : BaseViewModel
    {
        private ObservableCollection<Person> _persons;
        private Person _selectedPerson;
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _addCommand;

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                OnPropertyChanged();
                _selectedPerson = value;
            }
        }

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                       (_deleteCommand = new RelayCommand<object>(DeleteImplementation, o =>CanExecuteDeleteCommand()));
            }
        }
        public RelayCommand<object> AddCommand =>
            _addCommand ??
            (_addCommand = new RelayCommand<object>(AddImplementation));

        public bool CanExecuteDeleteCommand()
        {
            return _selectedPerson != null;
        }
        private void DeleteImplementation(object obj)
        {
            StationManager.DataStorage.DeletePerson(SelectedPerson);
        }

        private void AddImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.PersonInput);
        }

        private void UpdateList()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            OnPropertyChanged($"Persons");
        }

        internal PersonsListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            StationManager.DataStorage._collectionChanged += DataStorage__collectionChanged;
        }

        private void DataStorage__collectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
           UpdateList();
        }
    }
}
