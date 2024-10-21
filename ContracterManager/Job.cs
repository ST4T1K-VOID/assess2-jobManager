using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContracterManager
{
    class Job
    {
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool Completed { get; set; } = false;
        public Contractor? AssignedContractor { get; set; } = null;

        public Job(string title, decimal cost)
        {
            Title = title;
            Cost = cost;
        }

        public override string ToString()
        {
            string costString = Cost.ToString();
            string completedString;
            if (Completed == false)
            {
                completedString = "ongoing";
            }
            else
            {
                completedString = "Completed";
            }
            string dateString = DateCreated.ToString("dd-MM-yyyy");
            if (AssignedContractor != null)
            {
                string contractorString = string.Join(" ", [AssignedContractor.FirstName, AssignedContractor.LastName]);
                return $"{Title} | ${costString} | {completedString} | {contractorString}";
            }
            else if (Completed == true)
            {
                return $"{Title} |  ${costString} | {completedString}";
            }
            else
            {
                return $"{Title} | ${costString} | {completedString} | Job unassigned";
            }
        }
    }
}
