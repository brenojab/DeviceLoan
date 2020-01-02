using DeviceLoan.Models;
using DeviceLoan.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeviceLoan.ViewModels
{
    public class NewLoanViewModel : BaseViewModel
    {
        private Loan _loan = null;

        public Loan Loan
        {
            get { return _loan; }
            set { SetProperty(ref _loan, value); }
        }

        public Command AddLoadCommand { get; set; }

        public LoanDB LoanDB = null;

        public NewLoanViewModel()
        {
            Loan = new Loan();
            LoanDB = new LoanDB();

            AddLoadCommand = new Command(() => { AddLoan(); });
        }


        private void AddLoan()
        {
            Loan.Id = Guid.NewGuid();
            Loan.CreatedAt = Loan.ModifiedAt = Loan.LoanDevolutionDate= DateTime.Now;
            string r = LoanDB.AddLoan(Loan);
        }
    }
}
