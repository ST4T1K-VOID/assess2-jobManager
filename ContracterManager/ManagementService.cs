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
            AddContractor(101, "Bob", "Smith", Convert.ToDecimal(24.30), DateOnly.Parse("12-12-2001"));
            AddContractor(102, "Jane", "Smith", Convert.ToDecimal(24.00), DateOnly.Parse("5-7-1999"));
            AddContractor(103, "Smelly", "JR", Convert.ToDecimal(100.05), DateOnly.Parse("29-1-3025"));
            AddContractor(104, "Peter", "Pator", Convert.ToDecimal(24.10), DateOnly.Parse("25-2-2011"));
            AddContractor(105, "Potatoe", "Joe", Convert.ToDecimal(0.20), DateOnly.Parse("01-01-0001"));
            AddContractor(106, "Billy", "Bob", Convert.ToDecimal(50.00), DateOnly.Parse("12-12-1999"));

            AddJob("Lay bricks", Convert.ToDecimal(300.99));
            AddJob("forge sacred blade", Convert.ToDecimal(2500.70));
            AddJob("lay roof tiles", Convert.ToDecimal(320.50));
            AddJob("install light fixtures", Convert.ToDecimal(199.99));
            AddJob("banish evil", Convert.ToDecimal(0.01));
            AssignJob(Jobs[0], Contractors[0]);
        }
        public void AddContractor(int contractorID, string firstName, string lastName, decimal rate, DateOnly startDate)
        {
            Contractors.Add(new Contractor( contractorID, firstName, lastName, rate, startDate));
        }
        public bool RemoveContractor(Contractor targetContractor)
        {
            foreach (Contractor contractor in Contractors)
            {
                if (contractor.ContractorID == targetContractor.ContractorID)
                {
                    Contractors.Remove(contractor);
                    return true;
                }
            }
            return false;
        }
        public void AddJob(string jobTitle, decimal cost)
        {
            Jobs.Add(new Job(jobTitle, cost));
        }
        public string AssignJob(Job selectedJob, Contractor selectedContractor)
        {
            if (selectedJob.AssignedContractor != null)
            {
                return "Job has already been assigned";
            }
            else if (selectedJob.Completed == true)
            {
                return "Job has already been completed";
            }

            foreach (Job job in Jobs)
            {
                if (selectedContractor == job.AssignedContractor)
                {
                    return "Contractor already assigned to a job";
                }
            }
            selectedJob.AssignedContractor = selectedContractor;
            return "Job successfully assigned";
        }
        public void CompleteJob(Job selectedJob)
        {
            selectedJob.Completed = true;
            selectedJob.AssignedContractor = null;
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
            List<Contractor> availableContractors = Contractors;
            foreach (Job job in Jobs)
            {
                if (job.AssignedContractor != null)
                {
                    availableContractors.Remove(job.AssignedContractor);
                }
            }
            return availableContractors;
        }
        public List<Job> GetAvailableJobs()
        {
            List<Job> availableJobs = new List<Job>();
            foreach (Job job in Jobs)
            {
                if (job.AssignedContractor == null && job.Completed == false)
                {
                    availableJobs.Add(job);
                }
            }
            return availableJobs;
        }
        public List<Job> GetJobsByCost(decimal high, decimal low)
        {
            ////THIS IS WRONG
            //// MUST BE GIVE JOBS WITHIN A GIVEN RANGE
            //List<Job> jobsSorted = Jobs.OrderBy(Job => Job.Cost).ToList();
            //return jobsSorted;
            List<Job> jobsWithinRange = new List<Job>();
            foreach (Job job in Jobs)
            {
                if (job.Cost > low && job.Cost < high)
                {
                    jobsWithinRange.Add(job);
                }
            }
            return jobsWithinRange;
        }
    }
}
