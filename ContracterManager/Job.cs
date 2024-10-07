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
        //public DateOnly DateCreated { get; set; }
        public bool Completed { get; set; } = false;
        public Contractor AssignedContractor { get; set; } = null;

        public Job(string title, decimal cost)
        {
            Title = title;
            Cost = cost;
            //DateCreated = date;
        }

        public override string ToString()
        {
            string costString = Cost.ToString();
            string completedString;
            if (Completed == false)
            {
                completedString = "in progress";
            }
            else
            {
                completedString = "Completed";
            }
            if (AssignedContractor != null)
            {
                string contractorString = AssignedContractor.ToString();
                return $"{Title} || {costString} || {completedString} || {AssignedContractor}";
            }
            else
            {
                return $"{Title} || ${costString} || {completedString} || Job unassigned";
            }
        }
    }
}
