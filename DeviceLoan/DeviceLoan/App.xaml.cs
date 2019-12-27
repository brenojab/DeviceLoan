using DeviceLoan.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeviceLoan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoanListPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
