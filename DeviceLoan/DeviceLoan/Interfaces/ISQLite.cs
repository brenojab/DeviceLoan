using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceLoan.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection CreateConnection();
    }
}
