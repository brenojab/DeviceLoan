using DeviceLoan.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace DeviceLoan.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private ObservableCollection<Loan> _historyListSource = null;

        public ObservableCollection<Loan> HistoryListSource
        {
            get { return _historyListSource; }
            set { SetProperty(ref _historyListSource, value); }
        }

        

        public HistoryViewModel()
        {
           

            HistoryListSource = new ObservableCollection<Loan>()
            {
                // LoadDeviceLoans
            };
        }

    }
}
