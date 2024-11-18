using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContracterManager
{
    public class ManagementService
    {
        private List<Contractor> contractors = new List<Contractor>();

        private List<Job> jobs = new List<Job>();
 
        public ManagementService()
        {
            AddContractor(101, "Bob", "Smith", Convert.ToDecimal(24.30), DateOnly.Parse("12-12-2001"));
            AddContractor(102, "Jane", "Smith", Convert.ToDecimal(24.00), DateOnly.Parse("5-7-1999"));
            AddContractor(103, "Smelly", "JR", Convert.ToDecimal(100.05), DateOnly.Parse("29-1-3025"));
            AddContractor(104, "Peter", "Pator", Convert.ToDecimal(24.10), DateOnly.Parse("25-2-2011"));
            AddContractor(105, "Potatoe", "Joe", Convert.ToDecimal(0.20), DateOnly.Parse("01-01-0001"));
            AddContractor(106, "Billy", "Bob", Convert.ToDecimal(50.00), DateOnly.Parse("12-12-1999"));

            AddJob("Lay bricks", 300);
            AddJob("forge sacred blade", 2500);
            AddJob("lay roof tiles", 320);
            AddJob("install light fixtures", 199);
            AddJob("banish evil", 1);
            AssignJob(jobs[0], contractors[0]);
        }
        /// <summary>
        /// Adds a Contractor.
        /// </summary>
        /// <param name="contractorID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="rate"></param>
        /// <param name="startDate"></param>
        public void AddContractor(int contractorID, string firstName, string lastName, decimal rate, DateOnly startDate)
        {
            if (contractorID < 0)
            {
                return;
            }
            else if (rate < 0)
            {
                return;
            }
            contractors.Add(new Contractor(contractorID, firstName, lastName, rate, startDate));
        }
        /// <summary>
        /// Removes a contractor
        /// </summary>
        /// <param name="targetContractor"></param>
        public void RemoveContractor(Contractor targetContractor)
        {
            if (targetContractor == null)
            {
                return;
            }

            foreach (Contractor contractor in contractors.ToList())
            {
                if (contractor.ContractorID == targetContractor.ContractorID)
                {
                    contractors.Remove(contractor);
                }
            }
        }
        /// <summary>
        /// Adds a Job
        /// </summary>
        /// <param name="jobTitle"></param>
        /// <param name="cost"></param>
        public void AddJob(string jobTitle, int cost)
        {
            if (cost < 0)
            {
                return;
            }

            jobs.Add(new Job(jobTitle, cost));
        }
        /// <summary>
        /// Assigns a Contractor to a Job
        /// </summary>
        /// <param name="selectedJob"></param>
        /// <param name="selectedContractor"></param>
        /// <returns></returns>
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

            foreach (Job job in jobs)
            {
                if (selectedContractor == job.AssignedContractor)
                {
                    return "Contractor already assigned to a job";
                }
            }
            selectedJob.AssignedContractor = selectedContractor;
            return "Job successfully assigned";
        }
        /// <summary>
        /// Completes a job
        /// </summary>
        /// <param name="selectedJob"></param>
        public void CompleteJob(Job selectedJob)
        {
            selectedJob.Completed = true;
            selectedJob.AssignedContractor = null;
        }
        /// <summary>
        /// returns a list of all contractors
        /// </summary>
        /// <returns></returns>
        public List<Contractor> GetContractors()
        {
            List<Contractor> contractorsList = contractors.ToList();
            return contractorsList;
        }
        /// <summary>
        /// returns a list of all Jobs
        /// </summary>
        /// <returns></returns>
        public List<Job> GetJobs()
        {
            List<Job> jobsList = jobs.ToList();
            return jobsList;
        }
        /// <summary>
        /// Returns a list of all contractors not assigned to a job
        /// </summary>
        /// <returns></returns>
        public List<Contractor> GetAvailableContractors()
        {
            List<Contractor> availableContractors = contractors.ToList();
            foreach (Job job in jobs)
            {
                if (job.AssignedContractor != null)
                {
                    availableContractors.Remove(job.AssignedContractor);
                }
            }
            return availableContractors;
        }
        /// <summary>
        /// returns a list of all jobs without an assigned contractor
        /// </summary>
        /// <returns></returns>
        public List<Job> GetAvailableJobs()
        {
            List<Job> availableJobs = new List<Job>();
            foreach (Job job in jobs)
            {
                if (job.AssignedContractor == null && job.Completed == false)
                {
                    availableJobs.Add(job);
                }
            }
            return availableJobs;
        }

        /// <summary>
        /// returns a list of jobs within the specified range of cost
        /// </summary>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <returns></returns>
        public List<Job>? GetJobsByCost(decimal high, decimal low)
        {
            if (high == 0)
            {
                return null;
            }
            else if (high < 0 || low < 0)
            {
                return null;
            }
            else if (high < low)
            {
                return null;
            }

            List<Job> jobsWithinRange = new List<Job>();
            foreach (Job job in jobs)
            {
                if (job.Cost >= low && job.Cost <= high)
                {
                    jobsWithinRange.Add(job);
                }
            }
            return jobsWithinRange;
        }
    }
}
