using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceLoan.Models
{
    public class Device : BaseModel
    {
        public string Description { get; set; }

        public bool IsLoaned { get; set; }

        public string LoanDevolutionDate { get; set; }
    }
}
