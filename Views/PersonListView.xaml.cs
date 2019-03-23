using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Lab4.Models;
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

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit && e.Column.DisplayIndex==2)
            {
                var el = e.EditingElement as TextBox;
                string newString = el.Text;
                if (!Regex.IsMatch(newString, @"^[A-Za-z0-9_][A-Za-z0-9_]*@[A-Za-z0-9_]+\.[A-Za-z0-9_]+$"))
                {
                    el.Text = ((Person)DataGrid.Items[e.Row.GetIndex()]).Email;
                    MessageBox.Show($"\"{newString}\" is not correct format for email.");
                }
            }
        }
    }
}
