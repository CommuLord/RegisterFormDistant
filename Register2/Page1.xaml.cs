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
using System.Windows.Shapes;

namespace Register2
{
    public partial class Page1 : Window
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void btnSubmit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            if (mainWindow.ShowDialog() == true)
            {
                User user = mainWindow.user;
                label.Text = "Здравствуйте, " + user.Username;
            }
        }
    }
}
