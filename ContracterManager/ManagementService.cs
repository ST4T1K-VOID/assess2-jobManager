using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContracterManager
{
    class ManagementService
    {
        private List<Contractor> Contractors = new List<Contractor>();

        private List<Job> Jobs = new List<Job>();
 
        public ManagementService()
        {
            AddContractor(101, "Bob", "Smith", Convert.ToDecimal(24.30));
            AddContractor(102, "Jane", "Smith", Convert.ToDecimal(24.00));
            AddContractor(103, "Smelly", "JR", Convert.ToDecimal(100.05));
            AddContractor(104, "Peter", "Pater", Convert.ToDecimal(24.10));
            AddContractor(105, "Potatoe", "Joe", Convert.ToDecimal(0.20));
            AddContractor(106, "Billy", "Bob", Convert.ToDecimal(50.00));

            AddJob("Lay bricks", Convert.ToDecimal(300.99));
            AddJob("lay roof tiles", Convert.ToDecimal(320.50));
            AddJob("install light fixtures", Convert.ToDecimal(199.99));


        }
        //TODO add date
        public void AddContractor(int contractorID, string firstName, string lastName, decimal rate)
        {
            Contractors.Add(new Contractor( contractorID, firstName, lastName, rate));
        }
        public bool RemoveContractor(Contractor targetContractor, List<Contractor> contractors)
        {
            foreach (Contractor item in contractors)
            {
                if (item.ContractorID == targetContractor.ContractorID)
                {
                    contractors.Remove(item);
                }
                return true;
            }
            return false;
        }
        public void AddJob(string jobTitle, decimal cost)
        {
            Jobs.Add(new Job(jobTitle, cost));
        }
        public void AssignJob()
        {

        }
        public void CompleteJob()
        {
            
        }
        public List<Contractor> GetContractors()
        {
            List<Contractor> contractorsList = Contractors;
            return contractorsList;
        }
        public List<Job> GetJobs()
        {
            List<Job> jobsList = Jobs;
            return jobsList;
        }
        public List<Contractor> GetAvailableContractors()
        {
            return Contractors;
        }
        public List<Job> GetAvailableJobs()
        {
            return Jobs;
        }
        public List<Job> GetJobsByCost()
        {
            return GetJobs();
        }
    }
}
