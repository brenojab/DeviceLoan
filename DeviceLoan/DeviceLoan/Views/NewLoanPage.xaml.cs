using DeviceLoan.Models;
using DeviceLoan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeviceLoan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewLoanPage : ContentPage
    {
        public NewLoanViewModel ViewModel
        {
            get
            {
                return (NewLoanViewModel)BindingContext;
            }
        }

        public NewLoanPage()
        {
            InitializeComponent();
        }

        private async void AddLoan_Clicked(object sender, EventArgs e)
        {
            ViewModel.Loan.CreatedAt = DateTime.Now;
            ViewModel.Loan.ModifiedAt = DateTime.Now;

            ViewModel.AddLoadCommand.Execute(null);

            await Navigation.PopModalAsync();
        }
    }
}