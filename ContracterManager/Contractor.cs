using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContracterManager
{
    class Contractor
    {
        public int ContractorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Rate { get; set; }
        public DateOnly StartDate { get; set; }

        public Contractor(int contractorID, string firstName, string lastName, int rate, DateOnly startDate)
        {
            ContractorID = contractorID;
            FirstName = firstName;
            LastName = lastName;
            Rate = rate;
            StartDate = startDate;
        }
    }
}
