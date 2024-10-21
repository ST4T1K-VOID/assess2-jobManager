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

        public Tuple<decimal,decimal> SearchRange { get; private set; }

        private void button_confirm_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
