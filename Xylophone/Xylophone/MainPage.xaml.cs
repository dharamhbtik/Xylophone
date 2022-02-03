using System;
using Xamarin.Forms;

namespace Xylophone
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext= new MainPageViewModel();   
        }

    }
}
