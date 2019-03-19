using System.Windows.Controls;
using Lab4.Tools.Navigation;
using Lab4.ViewModels;

namespace Lab4.Views
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
