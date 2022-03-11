using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            TitleLabel.Text = Preferences.Get("Title", "none");
            BodyLabel.Text = Preferences.Get("Body", "none");
        }
    }
}