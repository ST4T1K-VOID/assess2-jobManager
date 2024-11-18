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
    /// Interaction logic for AddContractorWindow.xaml
    /// </summary>
    public partial class AddContractorWindow : Window
    {
        public AddContractorWindow()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_firstName.Text == string.Empty || textbox_lastName.Text == string.Empty || textbox_rate.Text == string.Empty || datepicker_date.Text == string.Empty)
            {
                MessageBox.Show("All Fields must be filled", "Empty Fields", MessageBoxButton.OK);
                return;
            }

            if (!textbox_firstName.Text.All(char.IsLetter) || !textbox_lastName.Text.All(char.IsLetter))
            {
                MessageBox.Show("first and last name may only contain letters", "Invalid input", MessageBoxButton.OK);
                return;
            }
            else if (!decimal.TryParse(textbox_rate.Text, out decimal result))
            {
                MessageBox.Show("Rate may only contain numbers or decimals", "Invalid input", MessageBoxButton.OK);
                return;
            }
            else if (decimal.Parse(textbox_rate.Text) < 0)
            {
                MessageBox.Show("Rate may only contain positive numbers", "", MessageBoxButton.OK);
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
