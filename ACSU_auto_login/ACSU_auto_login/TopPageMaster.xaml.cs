using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACSU_auto_login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopPageMaster : ContentPage
    {
        public ListView ListView;

        public TopPageMaster()
        {
            InitializeComponent();

            BindingContext = new TopPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class TopPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TopPageMenuItem> MenuItems { get; set; }
            
            public TopPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<TopPageMenuItem>(new[]
                {
                    new TopPageMenuItem { Id = 0, Title = "LOGIN",TargetType=typeof(TopPageDetail) },
                    new TopPageMenuItem { Id = 1, Title = "SERTTING",TargetType=typeof(SettingPageDetail)  },

                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}