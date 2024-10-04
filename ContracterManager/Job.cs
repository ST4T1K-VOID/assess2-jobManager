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
        public int Cost { get; set; }
        public DateOnly Date { get; set; }
        public bool Completed { get; set; } = false;
        public Contractor AssignedContractor { get; set; } = null;

        public Job(string title, int cost, DateOnly date, Contractor assignedContractor)
        {
            Title = title;
            Cost = cost;
            Date = date;
        }
    }

}
