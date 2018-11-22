using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ACSU_auto_login
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnClicked(object sender, EventArgs args)
        {
            try
            {
                ACSU_auto_login.login log = new ACSU_auto_login.login();
                this.labelHelloWorld.Text = log.result;
            }
            catch (Exception)
            {
                this.labelHelloWorld.Text = "error";


            }
            

        }
    }
}
