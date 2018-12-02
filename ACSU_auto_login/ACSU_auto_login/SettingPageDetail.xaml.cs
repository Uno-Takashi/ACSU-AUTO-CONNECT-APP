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
    public partial class SettingPageDetail : ContentPage
	{
        Entry IdEntry = new Entry { Placeholder = "id" , Margin = new Thickness(0) };
        Entry PasswordEntry = new Entry { Placeholder = "password" ,IsPassword=true};
        Switch BackgroundEntry = new Switch {  };
    public SettingPageDetail()
        {
            InitializeComponent();
            Button SaveButton = new Button
            {
                Text = "SAVE",

            };
            SaveButton.BackgroundColor = Color.FromRgb(120, 255, 120);
            SaveButton.Clicked += SaveOnClicked;
            Button ResetButton = new Button
            {
                Text = "Reset",
            };
            ResetButton.BackgroundColor = Color.FromRgb(255, 120, 120);
            ResetButton.Clicked += ResetOnClicked;

            var baselabel = new Label { Text = "", LineHeight = 0 ,Margin=new Thickness(0) };
            baselabel.Style = Device.Styles.TitleStyle;

            var accountlabel = new Label { Text = "", LineHeight = 0, Margin = new Thickness(0) };
            accountlabel.Style=Device.Styles.TitleStyle;
            accountlabel.Text = "Account";
            var BaseSettingLabel = new Label { Text = "", LineHeight = 0, Margin = new Thickness(0) };
            BaseSettingLabel.Style = Device.Styles.TitleStyle;
            BaseSettingLabel.Text = "Base Setting";

            if (Application.Current.Properties.ContainsKey("id"))
            {
                IdEntry.Text = Application.Current.Properties["id"] as string;
            }
            if (Application.Current.Properties.ContainsKey("password"))
            {
                PasswordEntry.Text = Application.Current.Properties["password"] as string;
            }

            TableView table = new TableView
            {
                Root = new TableRoot {

                    new TableSection ("Setting") {
                    
                    },
                },
                Intent = TableIntent.Settings
                
            };

            StackLayout buttonstack = new StackLayout
            {
                VerticalOptions = LayoutOptions.EndAndExpand,

                Children = {
                    SaveButton,
                    ResetButton
                }
            };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    accountlabel,
                    IdEntry,
                    PasswordEntry,
                    BaseSettingLabel,
                    //BackgroundEntry,
                    buttonstack

                }
            };


        }
        private void SaveOnClicked(object sender, EventArgs args)
        {
            Application.Current.Properties["id"] = IdEntry.Text;
            Application.Current.Properties["password"] = PasswordEntry.Text;
            DisplayAlert("Message", "Save this setting", "OK");

        }
        private void ResetOnClicked(object sender, EventArgs args)
        {
            DisplayAlert("Message", "Reset all setting", "OK");
            IdEntry.Text = "";
            PasswordEntry.Text = "";
            if (Application.Current.Properties.ContainsKey("id")) {
                Application.Current.Properties["id"] = "";
            }
            if (Application.Current.Properties.ContainsKey("password"))
            {
                Application.Current.Properties["password"] = "";
            }

        }
    }

}