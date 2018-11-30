﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ACSU_auto_login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TopPage();
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
