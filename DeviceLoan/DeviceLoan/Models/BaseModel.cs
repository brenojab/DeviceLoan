using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceLoan.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
