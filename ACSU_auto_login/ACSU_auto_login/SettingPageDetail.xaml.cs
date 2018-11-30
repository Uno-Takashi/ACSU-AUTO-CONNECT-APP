using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACSU_auto_login
{

    public class PasswordEntryCell : EntryCell
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                setStars();
            }
        }

        private string starFiller(int count)
        {
            var output = "";
            for (; count > 0; count--, output += "●")
                ;
            return output;
        }

        private void setStars()
        {
            this.Text = starFiller(this.Value.Length);
        }

        public PasswordEntryCell()
        {
            this.Value = "";
            this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                if (e.PropertyName == "Text")
                {
                    var txtLen = this.Text.Length;
                    var txtVal = this.Text;
                    var mdlLen = this.Value.Length;
                    if (txtLen > mdlLen)
                    {
                        this.Value += txtVal.Substring(txtLen - 1);
                    }
                    else
                    {
                        this.Value = this.Value.Substring(0, txtLen);
                    }
                    setStars();
                }
            };
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPageDetail : ContentPage
	{
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

            TableView table = new TableView
            {
                Root = new TableRoot {

                    new TableSection ("Setting") {
                    new EntryCell{Placeholder="id" },
                    new PasswordEntryCell{Placeholder="password" },
                    new SwitchCell {Text = "Background", On = false},
                    },
                },
                Intent = TableIntent.Settings
                
            };
            Content = new StackLayout
            {
                Children = {
                    table,
                    SaveButton,
                    ResetButton

                }
            };


        }
        private void SaveOnClicked(object sender, EventArgs args)
        {
            DisplayAlert("Message", "Save this setting", "OK");
        }
        private void ResetOnClicked(object sender, EventArgs args)
        {
            DisplayAlert("Message", "Reset all setting", "OK");
        }
    }

}