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
using System.Windows.Shapes;

namespace ContracterManager
{
    /// <summary>
    /// Interaction logic for ByCostWindow.xaml
    /// </summary>
    public partial class ByCostWindow : Window
    {
        public ByCostWindow()
        {
            InitializeComponent();
        }
        private void button_confirm_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_max.Text == string.Empty || textbox_min.Text == string.Empty)
            {
                MessageBox.Show("All fields must be filled", "Invalid input", MessageBoxButton.OK);
                return;
            }

            if (!textbox_max.Text.All(char.IsDigit) || !textbox_min.Text.All(char.IsDigit))
            {
                MessageBox.Show("Only enter numbers", "Invalid input", MessageBoxButton.OK);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
