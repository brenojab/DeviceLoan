using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceLoan.Models
{
    public class BaseModel
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
