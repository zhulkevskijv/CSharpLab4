using System.Windows;
using System.Windows.Controls;
using Lab03.Tools;
using Lab03.Tools.Navigation;
using Lab03.ViewModels;

namespace Lab03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.PersonInput);

        }
    }
}
