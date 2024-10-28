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
        public decimal Rate { get; set; }
        public DateOnly StartDate { get; set; }

        public Contractor(int contractorID, string firstName, string lastName, decimal rate, DateOnly startDate)
        {
            ContractorID = contractorID;
            FirstName = firstName;
            LastName = lastName;
            Rate = rate;
            StartDate = startDate;
        }

        public override string ToString()
        {
            string iDString = ContractorID.ToString();
            string fNameString = FirstName;
            string lNameString = LastName;
            string rateString = Rate.ToString();

            return $"{iDString} | {fNameString} {lNameString} | {rateString}";
        }
    }
}
