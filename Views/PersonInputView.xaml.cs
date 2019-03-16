using System.Windows.Controls;
using Lab03.Tools.Navigation;
using Lab03.ViewModels;

namespace Lab03.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonInputView.xaml
    /// </summary>
    public partial class PersonInputView : UserControl, INavigatable
    {
        public PersonInputView()
        {
            InitializeComponent();
            DataContext = new PersonInputViewModel();
        }
    }
}
