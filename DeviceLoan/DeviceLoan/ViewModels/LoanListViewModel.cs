using DeviceLoan.Models;
using DeviceLoan.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace DeviceLoan.ViewModels
{
    public class LoanListViewModel : BaseViewModel
    {
        private LoanDB LoanDB = null;

        private bool _isLoaned = false;
        public bool IsLoaned
        {
            get { return _isLoaned; }
            set { SetProperty(ref _isLoaned, value); }
        }

        public Command SwitchTappedCommand { get; set; }

        public Command LoadLoanCommand { get; set; }

        public Command UpdateLoanCommand { get; set; }

        public ObservableCollection<Loan> ListSource { get; set; }

        public LoanListViewModel()
        {
            LoadLoanCommand = new Command(() => LoadLoan());

            UpdateLoanCommand = new Command<Guid>((id) => UpdateLoan(id));

            SwitchTappedCommand = new Command<Guid>((id) => SwitchTapped(id));

            LoanDB = new LoanDB();

            ListSource = new ObservableCollection<Loan>();

            LoadLoan();


        }

        private void SwitchTapped(Guid id)
        {
            throw new NotImplementedException();
        }

        private void UpdateLoan(Guid id)
        {
            throw new NotImplementedException();
        }

        private void LoadLoan()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ListSource.Clear();

                IEnumerable<Loan> loans = null;
                
                loans = LoanDB.GetLoans();

                var items = new ObservableCollection<Loan>(loans);

                ListSource = items;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
