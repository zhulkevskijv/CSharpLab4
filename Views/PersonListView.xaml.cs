using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Lab4.Tools.DataStorage;
using Lab4.Tools.Managers;
using Lab4.Tools.Navigation;
using Lab4.ViewModels;

namespace Lab4.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonListView.xaml
    /// </summary>
    public partial class PersonListView : UserControl, INavigatable
    {
        public PersonListView()
        {
            InitializeComponent();
            DataContext = new PersonsListViewModel();
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                ((SerializedDataStorage)StationManager.DataStorage).SaveChanges();
                Thread.Sleep(1000);
            });
            LoaderManager.Instance.HideLoader();
           
        }
    }
}
