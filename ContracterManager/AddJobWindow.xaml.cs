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
    /// Interaction logic for AddJobWindow.xaml
    /// </summary>
    public partial class AddJobWindow : Window
    {
        public AddJobWindow()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void button_confirm_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_title.Text == string.Empty || textbox_cost.Text == string.Empty)
            {
                MessageBox.Show("All Fields must be filled", "Empty Fields", MessageBoxButton.OK);
                return;
            }
            if (!textbox_title.Text.All(char.IsLetter))
            {
                MessageBox.Show("Title may only include letters", "Invalid input", MessageBoxButton.OK);
                return;
            }
            else if (!textbox_cost.Text.All(char.IsDigit))
            {
                MessageBox.Show("Rate may only contain numbers", "Invalid input", MessageBoxButton.OK);
                return;
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
