﻿using App5.Services;
using App5.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
