using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using WpfApplication1;



namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AddCustomerViewModel();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {

            //Directory.CreateDirectory(pathString);
            var dataContext = (DataContext as AddCustomerViewModel);
            if(dataContext != null)
            {
                dataContext.IsDeleteCustomerPageOpen = false;
                dataContext.IsChooseDirectoryOpen = false;
                dataContext.IsAddCustomerPageOpen = true;
            }
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {                   
            var dataContext = (DataContext as AddCustomerViewModel);
            if (dataContext != null)
            {
                dataContext.IsAddCustomerPageOpen = false;
                dataContext.IsChooseDirectoryOpen = false;
                dataContext.IsDeleteCustomerPageOpen = true;             
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = (DataContext as AddCustomerViewModel);
            if (dataContext != null)
            {
                string workingDirectory = @"" + dataContext.WorkingDirectory;
                var extension = ".txt";
                var filename = dataContext.CustomerFirstName + dataContext.CustomerLastName + extension;
                string newFile = Path.Combine(workingDirectory, filename);
                var output = dataContext.CreateOutput();
                File.WriteAllLines(newFile, output);
                dataContext.ClearAllProperties();                
            }
        }

        private void DeleteFileButton_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = (DataContext as AddCustomerViewModel);
            if (dataContext != null)
            {
                string workingDirectory = @"" + dataContext.WorkingDirectory;
                var extension = ".txt";
                var filename = dataContext.FileToDelete + extension;
                var fullDeletePath = Path.Combine(workingDirectory, filename);
                if (File.Exists(fullDeletePath))
                {
                    File.Delete(fullDeletePath);
                    dataContext.FileToDelete = null;
                }
                else
                {
                    MessageBox.Show("The file you are attempting to delete does not exist.");
                }
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            if (addButton != null)
            {
                addButton.ContextMenu.IsOpen = true;
                addButton.ContextMenu.PlacementTarget = addButton;
            }
        }

        private void ChooseDirectory_MenuItemClick(object sender, RoutedEventArgs e)
        {
            var dataContext = (DataContext as AddCustomerViewModel);
            if (dataContext != null)
            {
                dataContext.IsAddCustomerPageOpen = false;
                dataContext.IsDeleteCustomerPageOpen = false;
                dataContext.IsChooseDirectoryOpen = true;
            }
        }

        private void ChangeDirectory_ButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = (DataContext as AddCustomerViewModel);
            if (dataContext != null)
            {                
                dataContext.IsChooseDirectoryOpen = false;
            }
        }

        private void CancelDirectoryChange_ButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = (DataContext as AddCustomerViewModel);
            if (dataContext != null)
            {               
                dataContext.IsChooseDirectoryOpen = false;
            }
        }
    }
}
