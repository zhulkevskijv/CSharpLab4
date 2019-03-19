using System.Windows.Controls;
using Lab4.Tools.Navigation;
using Lab4.ViewModels;

namespace Lab4.Views
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
