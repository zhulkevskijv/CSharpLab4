using System.Windows.Controls;
using Lab03.Tools.Navigation;
using Lab03.ViewModels;

namespace Lab03.Views
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class ResultView : UserControl, INavigatable
    {
        public ResultView()
        {
            InitializeComponent();
            DataContext = new ResultViewModel();
        }
    }
}
