using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


namespace BillApp
{

    public partial class MainWindow : Window
    {
        MenuViewModel menuData = new MenuViewModel();
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = menuData;
        }

        private void MenuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ComboBox = (ComboBox)sender;
            var SelectedItem = (MenuItem)ComboBox.SelectedItem;
            menuData.HandleSelectedItem(SelectedItem);
            ComboBox.SelectedItem = null;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;
            var Selected = (MenuItem)Button.DataContext;
            menuData.Selected.Remove(Selected);
        }
        
        private void DeleteAllButton_Click(object sender, RoutedEventArgs e)
        {
            menuData.Selected.Clear();
        }


        //private bool itemAddedAfterSelectionChanged = false;


        //private void ComboBox_DropDownClosed(object sender, EventArgs e)
        //{
        //    var comboBox = (ComboBox)sender;
        //    var selectedItem = (MenuItem)comboBox.SelectedItem;

        //    if (!itemAddedAfterSelectionChanged)
        //    {
        //        menuData.HandleSelectedItem(selectedItem);
        //    }
        //    itemAddedAfterSelectionChanged = false;
        //    comboBox.SelectedItem = null;
        //}




    }

        



    }