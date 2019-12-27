using DeviceLoan.Interfaces;
using DeviceLoan.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeviceLoan.Data
{
    public class DatabaseManager
    {
        SQLiteConnection dbConnection;
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<ISQLite>().CreateConnection();
        }

        public List<Loan> GetAllItems()
        {
            return dbConnection.Query<Loan>("Select * From [Loan]");
        }

        public int SaveItem(Loan loan)

        {
            return dbConnection.Insert(loan);
        }
    }
}
