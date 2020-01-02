using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceLoan.Models
{
    public class Loan : BaseModel
    {
        public string DeviceDescription { get; set; }

        public bool IsLoaned { get; set; }

        public DateTime LoanDevolutionDate { get; set; }

        public string WhosCaugth { get; set; }
    }
}
