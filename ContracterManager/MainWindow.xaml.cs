using ContracterManager;
using Microsoft.Windows.Themes;
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
            RefreshContractorsList(contractorFilter);
            RefreshJobsList(jobFilter);
            combo_jobFilter.ItemsSource = Enum.GetValues(typeof(JobFilter));
        }

        public enum JobFilter
        {
            None = 0,
            ByAvailable = 1,
            ByCost = 2,
        }
        JobFilter jobFilter = 0;
        JobFilter previousFilter = 0;
        bool contractorFilter = false;

        // Refresh methods
        void RefreshContractorsList(bool filter = false)
        {
            if (filter == false)
            {
                list_contractors.ItemsSource = null;
                list_contractors.ItemsSource = service.GetContractors();
            }
            else if (filter == true) 
            {
                list_contractors.ItemsSource= null;
                list_contractors.ItemsSource = service.GetAvailableContractors();
            }
        }
        void RefreshJobsList(JobFilter filter)
        {
            if ((int)filter == 0) //none
            {
                list_jobs.ItemsSource = null;
                list_jobs.ItemsSource = service.GetJobs();
            }
            else if ((int)filter == 1) //byavailable
            {
                list_jobs.ItemsSource = null;
                list_jobs.ItemsSource = service.GetAvailableJobs();
            }
            else // bycost
            {
                ByCostWindow byCostWindow = new ByCostWindow();
                byCostWindow.ShowDialog();
                if (byCostWindow.DialogResult == true)
                {
                    int max = int.Parse(byCostWindow.textbox_max.Text);
                    int min = int.Parse(byCostWindow.textbox_min.Text);

                    list_jobs.ItemsSource = null;
                    list_jobs.ItemsSource = service.GetJobsByCost(max, min);
                    jobFilter = previousFilter;
                    combo_jobFilter.SelectedItem = previousFilter;
                }
                else
                {
                    jobFilter = previousFilter;
                    combo_jobFilter.SelectedItem = previousFilter;
                }
            }
        }

        void button_GetContractors_Click(object sender, RoutedEventArgs e)
        {
            RefreshContractorsList(contractorFilter);
        }

        private void button_GetJobs_Click(object sender, RoutedEventArgs e)
        {
            RefreshJobsList(jobFilter);
        }
        //List methods
        private void list_contractors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list_contractors.SelectedItem == null)
            {
                return;
            }
            Contractor? selectedContractor = list_contractors.SelectedItem as Contractor;

            textBox_FirstName.Text = selectedContractor.FirstName;
            textBox_LastName.Text = selectedContractor.LastName;
            textbox_ID.Text = selectedContractor.ContractorID.ToString();
            textbox_Rate.Text = selectedContractor.Rate.ToString();
            textbox_StartDate.Text = selectedContractor.StartDate.ToString("dd-MM-yyyy");
            List<Job> jobs = service.GetJobs();
            foreach (Job job in jobs)
            {
                if (job.AssignedContractor == selectedContractor)
                {
                    textbox_AssignedJob.Text = job.Title;
                }
                else
                {
                    textbox_AssignedJob.Text = "Not assgined to a job";
                }
            }
        }
        private void list_jobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list_jobs.SelectedItem == null)
            {
                return;
            }
            Job? selectedJob = list_jobs.SelectedItem as Job;
            textbox_Title.Text = selectedJob.Title;
            textbox_cost.Text = ("$" + selectedJob.Cost.ToString());
            textbox_dateMade.Text = selectedJob.DateCreated.ToString("dd-MM-yyyy");
            if (selectedJob.AssignedContractor == null)
            {
                textbox_AssignedContractor.Text = "No one assigned to this job";
            }
            else
            {
                textbox_AssignedContractor.Text = string.Join("", [selectedJob.AssignedContractor.FirstName, selectedJob.AssignedContractor.LastName]);
            }
            if (selectedJob.Completed == true)
            {
                textbox_jobStatus.Text = "Completed";
            }
            else
            {
                textbox_jobStatus.Text = "Ongoing";
            }
            //TODO Show assigned job if contractor has one
        }
        //Filter methods
        private void checkbox_contractorFilter_Checked(object sender, RoutedEventArgs e)
        {
            contractorFilter = true;
            RefreshContractorsList(contractorFilter);
        }

        private void checkbox_contractorFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            contractorFilter = false;
            RefreshContractorsList(contractorFilter);
        }

        private void button_assignJob_Click(object sender, RoutedEventArgs e)
        {
            if (list_contractors.SelectedItem == null || list_jobs.SelectedItem == null)
            {
                return;
            }
            Contractor selectedContractor = list_contractors.SelectedItem as Contractor;
            Job selectedJob = list_jobs.SelectedItem as Job;

            string message = service.AssignJob( list_jobs.SelectedItem as Job, list_contractors.SelectedItem as Contractor);
            MessageBox.Show(message, "Operation result", MessageBoxButton.OK);
            RefreshJobsList(jobFilter);
            RefreshContractorsList(contractorFilter);
        }

        private void combo_jobFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_jobFilter.SelectedItem is JobFilter filter)
            {
                previousFilter = jobFilter;
                jobFilter = filter;
            }
        }

        //Doing stuff methods
        private void button_CompleteJob_Click(object sender, RoutedEventArgs e)
        {
            if (list_jobs.SelectedItem == null)
            {
                return;
            }
            service.CompleteJob(list_jobs.SelectedItem as Job);
            RefreshJobsList(jobFilter);
            RefreshContractorsList(contractorFilter);
        }
        private void button_remove_Click(object sender, RoutedEventArgs e)
        {
            if (list_contractors.SelectedItem == null)
            {
                return;
            }
            var result = MessageBox.Show("Are you sure you want to remove a contractor?", "Warning", MessageBoxButton.OKCancel);
            
            if (result == MessageBoxResult.OK)
            {
                service.RemoveContractor(list_contractors.SelectedItem as Contractor);
                RefreshContractorsList(contractorFilter);
            }
            else
            {
                return;
            }
        }

        private void button_addJob_Click(object sender, RoutedEventArgs e)
        {
            AddJobWindow addJobWindow = new AddJobWindow();
            addJobWindow.ShowDialog();
            if (addJobWindow.DialogResult == true)
            {
                service.AddJob(addJobWindow.textbox_title.Text, int.Parse(addJobWindow.textbox_cost.Text));
            }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            AddContractorWindow addContractorWindow = new AddContractorWindow();
            addContractorWindow.ShowDialog();
            if (addContractorWindow.DialogResult == true)
            {
                List<Contractor> tempContractors = service.GetContractors();
                Contractor tempContractor = tempContractors.Last();
                int contractorID = (tempContractor.ContractorID + 1);
                string firstName = addContractorWindow.textbox_firstName.Text;
                string lastName = addContractorWindow.textbox_lastName.Text;
                int rate = int.Parse(addContractorWindow.textbox_rate.Text);
                DateOnly date = DateOnly.Parse(addContractorWindow.datepicker_date.Text);

                service.AddContractor(contractorID, firstName, lastName, rate, date);
                RefreshContractorsList(contractorFilter);
            }
        }
    }
}
