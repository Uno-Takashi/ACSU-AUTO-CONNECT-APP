using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACSU_auto_login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopPageDetail : ContentPage
    {
        public TopPageDetail()
        {
            InitializeComponent();
        }
                private void OnClicked(object sender, EventArgs args)
        {
            try
            {
                ACSU_auto_login.login log = new ACSU_auto_login.login();

                DisplayAlert("タイトル", "CONNECTION SUCCESSFUL", "OK");
            }
            catch (Exception)
            {

                DisplayAlert("タイトル", "CONNECTION ERROE", "OK");


            }
            

        }
    }
}