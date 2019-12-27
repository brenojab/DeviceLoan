using DeviceLoan.Interfaces;
using DeviceLoan.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DeviceLoan.Services
{

    public class LoanDB
    {
        private SQLiteConnection _SQLiteConnection;

        public LoanDB()
        {
            _SQLiteConnection = DependencyService.Get<ISQLite>().CreateConnection();
            _SQLiteConnection.CreateTable<Loan>();
        }

        public IEnumerable<Loan> GetLoans()
        {
            return (from u in _SQLiteConnection.Table<Loan>()
                    select u).ToList();
        }

        public void DeleteLoan(Guid id)
        {
            _SQLiteConnection.Delete<Loan>(id);
        }

        public string AddLoan(Loan loan)
        {
            var data = _SQLiteConnection.Table<Loan>();

            var d1 = data.Where(x => x.Id == loan.Id).FirstOrDefault();

            if (d1 == null)
            {
                _SQLiteConnection.Insert(loan);
                return "Sucessfully Added";
            }
            else
                return "Already Mail id Exist";
        }
    }
}
