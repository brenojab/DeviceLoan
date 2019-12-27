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
    public partial class HistoryPage : ContentPage
    {
        public HistoryViewModel ViewModel
        {
            get
            {
                return (HistoryViewModel)BindingContext;
            }
        }



        public HistoryPage()
        {
            InitializeComponent();
        }
    }
}