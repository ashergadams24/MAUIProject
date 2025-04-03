using Microsoft.Maui.Controls;
using System;
using MAUIProject1.ViewModels;
using MAUIProject1.Views;

namespace MAUIProject1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }


        private async void StudentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentView()); 
        }

        private async void InstructorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InstructorView());
        }

    }
}