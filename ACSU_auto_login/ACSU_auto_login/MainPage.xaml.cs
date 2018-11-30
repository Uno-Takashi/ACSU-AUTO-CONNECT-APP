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
                if (Application.Current.Properties.ContainsKey("password") && Application.Current.Properties.ContainsKey("id") && Application.Current.Properties["id"] as string !="" && Application.Current.Properties["password"] as string != "")
                {
                    ACSU_auto_login.login log = new ACSU_auto_login.login(Application.Current.Properties["id"] as string, Application.Current.Properties["password"] as string);
                }
                else
                {
                    throw new WriteException();
                }


                DisplayAlert("Message", "CONNECTION SUCCESSFUL", "OK");
            }
            catch (WriteException)
            {
                DisplayAlert("Message", "PLEASE WHRITE ID & PASSWORD", "OK");
            }
            catch (Exception)
            {

                DisplayAlert("Message", "CONNECTION ERROE", "OK");


            }


        }
    }
}
