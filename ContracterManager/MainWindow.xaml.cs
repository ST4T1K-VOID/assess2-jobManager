using System.ComponentModel;
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

namespace ContracterManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManagementService service = new ManagementService();

        public MainWindow()
        {
            InitializeComponent();
            RefreshContractorsList();
            RefreshJobsList(filter);
        }
        public enum JobFilter
        {
            None = 0,
            ByAvailable = 1,
            ByCost = 2,
        }
        JobFilter filter = 0;

        void RefreshContractorsList(bool filter = false)
        {
            if (filter == false)
            {
                list_contractors.ItemsSource = null;
                list_contractors.ItemsSource = service.GetContractors();
            }
            else
            {
                list_contractors.ItemsSource= null;
                list_contractors.ItemsSource = service.GetAvailableContractors();
            }
        }
        void RefreshJobsList(JobFilter filter)
        {
            if ((int)filter == 0)
            {
                list_jobs.ItemsSource = null;
                list_jobs.ItemsSource = service.GetJobs();
            }
            else if ((int)filter == 1)
            {
                list_jobs.ItemsSource = null;
                list_jobs.ItemsSource = service.GetAvailableJobs();
            }
            else
            {
                list_jobs.ItemsSource= null;
                list_jobs.ItemsSource = service.GetJobsByCost();
            }
        }

        void button_GetContractors_Click(object sender, RoutedEventArgs e)
        {
            RefreshContractorsList();
        }

        private void list_contractors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contractor selectedContractor = list_contractors.SelectedItem as Contractor;
            if (selectedContractor != null)
            {
                selectedContractor = service.GetContractors()[1];
            }

            textBox_FirstName.Text = selectedContractor.FirstName;
            textBox_LastName.Text = selectedContractor.LastName;
            textbox_ID.Text = selectedContractor.ContractorID.ToString();
            textbox_Rate.Text = selectedContractor.Rate.ToString();
            


        }
    }
}

//list_contractors.ItemsSource = null;
//list_contractors.ItemsSource = service.GetContractors();