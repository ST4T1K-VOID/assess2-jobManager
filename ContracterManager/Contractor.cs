using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContracterManager
{
    class Contractor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Rate { get; set; }
        public DateOnly StartDate { get; set; }

        public Contractor(string firstName, string lastName, int rate, DateOnly startDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Rate = rate;
            StartDate = startDate;
        }
    }
}
