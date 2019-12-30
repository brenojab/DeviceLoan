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
    public partial class LoanListPage : ContentPage
    {
        public LoanListViewModel ViewModel
        {
            get
            {
                return (LoanListViewModel)BindingContext;
            }
        }

        public LoanListPage()
        {
            InitializeComponent();

            Lista.ItemSelected += async (s, e) =>
            {
                if (await DisplayAlert("teste", "Excluir?", "Excluir", "Não ainda..."))
                {
                    ViewModel.DeleteLoanCommand.Execute((e.SelectedItem as Loan).Id);
                    await Task.Delay(2000);
                    MessagingCenter.Send(this, "LoadLoanMessage");
                }
            };

        }

        private async void AddDevice_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewLoanPage()));
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (await DisplayAlert("teste", "Habilitar?", "Sim, agora!", "Não, espere..."))
            {
                var id = (((sender as Button).CommandParameter) as Loan).Id;

                ViewModel.UpdateLoanCommand.Execute(id);
            }
        }
    }
}