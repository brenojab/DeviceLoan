using DeviceLoan.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeviceLoan.ViewModels
{
    public class LoanListViewModel : BaseViewModel
    {
        private bool _isLoaned = false;
        public bool IsLoaned
        {
            get { return _isLoaned; }
            set { SetProperty(ref _isLoaned, value); }
        }

        public ObservableCollection<Device> ListSource { get; set; }

        public LoanListViewModel()
        {
            ListSource = new ObservableCollection<Device>()
            {
                new Device()
                {
                    IsLoaned = false,
                    LoanDevolutionDate = DateTime.Now.ToString(),
                    Description = "Samsung S9",

                },
                new Device()
                {
                    IsLoaned = true,
                    LoanDevolutionDate = DateTime.Now.AddDays(-2).ToString(),

                    Description = "iPhone XR"
                },
                 new Device()
                {
                    IsLoaned = false,
                    LoanDevolutionDate = DateTime.Now.AddDays(-4).ToString(),
                    Description = "Motorola G7 Plus"

                },
                 new Device()
                {
                    IsLoaned = true,
                    LoanDevolutionDate = DateTime.Now.AddDays(-7).ToString(),
                    Description = "iPhone XS Plus"

                },
            };
        }
    }
}
