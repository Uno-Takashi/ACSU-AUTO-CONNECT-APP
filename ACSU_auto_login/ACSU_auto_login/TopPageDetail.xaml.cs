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
    public class ImageButton : Image
    {
        public event EventHandler Tapped;

        /// <summary>
        /// アニメーション時間を取得または設定します。
        /// (デフォルト100ms)
        /// </summary>
        /// <value>アニメーション時間</value>
        public uint? AnimationTime { get; set; }

        /// <summary>
        /// アニメーションの際のスケールを取得または設定します。
        /// (デフォルト0.5)
        /// </summary>
        /// <value>アニメーションの際のスケール</value>
        public double? UnevennessScale { get; set; }

        public ImageButton() : base()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (sender, e) => OnClicked(sender, e);
            this.GestureRecognizers.Add(tgr);
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            var btn = sender as ImageButton;

            if (btn != null)
            {
                uint _animationTime;
                double _unevennessScale;

                // アニメーション時間の指定がなければデフォルト(100ms)
                if (AnimationTime is null)
                {
                    _animationTime = 100;
                }
                else
                {
                    _animationTime = (uint)AnimationTime;
                }

                //凹凸スケールの指定がなければデフォルト値(0.5)
                if (UnevennessScale is null)
                {
                    _unevennessScale = 0.5;
                }
                else
                {
                    _unevennessScale = (double)UnevennessScale;
                }

                await btn.ScaleTo(_unevennessScale, _animationTime);
                await btn.ScaleTo(1, _animationTime);

                
                
            }

            // アニメーション後に指定されたメソッドを実行
            if (Tapped != null)
            {

                Tapped(this, e);
            }
        }
    }
    public class WriteException : Exception
    {
        public WriteException()
        {
        }

        public WriteException(string message)
            : base(message)
        {
        }

        public WriteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public partial class TopPageDetail : ContentPage
    {
        public TopPageDetail()
        {
            InitializeComponent();
            ImageButton imb = new ImageButton { Source="acsu.png" , VerticalOptions = LayoutOptions.CenterAndExpand  };
            imb.Tapped += Clicked;
            StackLayout stack = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {
                    
                    imb
                }
            };
            Content = stack;

        }
        private void Clicked(object sender, EventArgs args)
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("password") && Application.Current.Properties.ContainsKey("id") && Application.Current.Properties["id"] as string != "" && Application.Current.Properties["password"] as string != "")
                {
                    ACSU_auto_login.login log = new ACSU_auto_login.login(Application.Current.Properties["id"] as string, Application.Current.Properties["password"] as string);
                }
                else
                {
                    throw new WriteException();
                }

                if (Application.Current.Properties.ContainsKey("success"))
                {
                    if ((bool)Application.Current.Properties["success"])
                    {

                    }
                    else
                    {
                        DisplayAlert("Message", "CONNECTION SUCCESSFUL", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Message", "CONNECTION SUCCESSFUL", "OK");
                }
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