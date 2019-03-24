using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lab4.Models;
using Lab4.Tools;
using Lab4.Tools.DataStorage;
using Lab4.Tools.Managers;
using Lab4.Tools.Navigation;

namespace Lab4.ViewModels
{
    class PersonsListViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<Person> _persons;
        private Person _selectedPerson;
        private string _filterText;
        private int _indexFilter;
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _saveCommand;
        private RelayCommand<object> _filterCommand;
        private RelayCommand<object> _clearCommand;
        private RelayCommand<object> _sortAscCommand;
        private RelayCommand<object> _sortDescCommand;
        #endregion 

        #region Constructor
        internal PersonsListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            StationManager.DataStorage._collectionChanged += DataStorage__collectionChanged;
        }
        #endregion

        #region Properties

        public string FilterText
        {
            get
            {
                return _filterText;
            }
            set
            {
                _filterText = value;
                OnPropertyChanged();
            }
        }

        public int IndexFilter
        {
            get { return _indexFilter; }
            set
            {
                _indexFilter = value;
                OnPropertyChanged();
            }
        }

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
        #endregion

        #region Command Properties

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                       (_deleteCommand = new RelayCommand<object>(DeleteImplementation, o => CanExecuteDeleteCommand()));
            }
        }

        public RelayCommand<object> AddCommand =>
            _addCommand ??
            (_addCommand = new RelayCommand<object>(AddImplementation));

        public RelayCommand<object> SaveCommand
        {
            get
            {
                return _saveCommand ??
                       (_saveCommand = new RelayCommand<object>(SaveImplementation));
            }
        }

        public RelayCommand<object> ClearCommand
        {
            get
            {
                return _clearCommand ??
                       (_clearCommand = new RelayCommand<object>(ClearImplementation));
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ??
                       (_filterCommand = new RelayCommand<object>(FilterImplementation, o => CanExecuteFilterCommand()));
            }
        }

        public RelayCommand<object> SortAscCommand
        {
            get
            {
                return _sortAscCommand ??
                       (_sortAscCommand = new RelayCommand<object>(SortAscImplementation));
            }
        }

        public RelayCommand<object> SortDescCommand
        {
            get
            {
                return _sortDescCommand ??
                       (_sortDescCommand = new RelayCommand<object>(SortDescImplementation));
            }
        }

        #endregion

        #region CommandImplementation

        public bool CanExecuteDeleteCommand()
        {
            return _selectedPerson != null;
        }

        public bool CanExecuteFilterCommand()
        {
            return !string.IsNullOrWhiteSpace(_filterText);
        }

        private void FilterImplementation(object obj)
        {
            switch (IndexFilter)
            {
                case (0):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.Name.Contains(FilterText)));
                    break;
                case (1):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.Surname.Contains(FilterText)));
                    break;
                case (2):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.Email.Contains(FilterText)));
                    break;
                case (3):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.Birthday.ToString("dd.MM.yyyy").Contains(FilterText.ToLower())));
                    break;
                case (4):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.IsAdult.ToString().Contains(FilterText)));
                    break;
                case (5):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.WestHoroSign.Contains(FilterText)));
                    break;
                case (6):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.ChineseHoroSign.Contains(FilterText)));
                    break;
                case (7):
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList.Where(person => person.IsBirthday.ToString().Contains(FilterText)));
                    break;
            }
            OnPropertyChanged($"Persons");
        }

        private void DeleteImplementation(object obj)
        {
            StationManager.DataStorage.DeletePerson(SelectedPerson);
        }

        private void AddImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.PersonInput);
        }

        private async void SaveImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                ((SerializedDataStorage)StationManager.DataStorage).SaveChanges();
                Thread.Sleep(1000);
            });
            LoaderManager.Instance.HideLoader();
        }

        private async void ClearImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Thread.Sleep(200);
                FilterText = "";
                Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            });
            LoaderManager.Instance.HideLoader();
        }

        private void SortAscImplementation(object obj)
        {
            switch (IndexFilter)
            {
                case (0):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.Name));
                    break;
                case (1):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.Surname));
                    break;
                case (2):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.Email));
                    break;
                case (3):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.Birthday));
                    break;
                case (4):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.IsAdult.ToString()));
                    break;
                case (5):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.WestHoroSign));
                    break;
                case (6):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.ChineseHoroSign));
                    break;
                case (7):
                    _persons = new ObservableCollection<Person>(_persons.OrderBy(i => i.IsBirthday.ToString()));
                    break;
            }

            _selectedPerson = null;
            OnPropertyChanged($"Persons");
        }

        private void SortDescImplementation(object obj)
        {
            switch(IndexFilter)
            {
                case (0):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.Name));
                break;
                case (1):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.Surname));
                break;
                case (2):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.Email));
                break;
                case (3):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.Birthday));
                break;
                case (4):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.IsAdult.ToString()));
                break;
                case (5):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.WestHoroSign));
                break;
                case (6):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.ChineseHoroSign));
                break;
                case (7):
                _persons = new ObservableCollection<Person>(_persons.OrderByDescending(i => i.IsBirthday.ToString()));
                break;
            }
            _selectedPerson = null;
            OnPropertyChanged($"Persons");
        }

        #endregion

        #region ColectionEvents

        private void DataStorage__collectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            OnPropertyChanged($"Persons");
        }

        #endregion

    }
}
