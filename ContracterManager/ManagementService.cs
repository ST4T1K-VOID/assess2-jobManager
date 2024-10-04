using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContracterManager
{
    class ManagementService
    {
        List<Contractor> Contractors = new List<Contractor>();

        List<Job> Jobs = new List<Job>();
        
        Job job = new jobb
 
        public void AddContractor(int ID, string firstName, string lastName, int rate, DateOnly date)
        {
            Contractors.Add(new Contractor( ID, firstName, lastName, rate, date));
        }
        public bool RemoveContractor(Contractor contractor, List<Contractor> contractors)
        {
            foreach (Contractor item in contractors)
            {
                if (item.ContractorID == contractor.ContractorID)
                {
                    contractors.Remove(item);
                }
                return true;
            }
            return false;
        }
        public void AddJob()
        {

        }
        public void AssignJob()
        {

        }
        public void CompleteJob()
        {

        }
        public void GetContractors()
        {

        }
        public void GetJobs()
        {

        }
        public void GetAvailableContractors()
        {

        }
        public void GetAvailableJobs()
        {

        }
        public void GetJobsByCost()
        {

        }
    }
}
