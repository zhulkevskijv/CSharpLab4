using System.Windows.Controls;
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
    }
}
