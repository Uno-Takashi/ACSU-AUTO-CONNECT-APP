using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACSU_auto_login
{

        //DependencyServiceから利用する
        public interface INotificationService
        {
            //iOS用の登録
            void Regist();
            //通知する
            void On(string title, string body);
            //通知を解除する
            void Off();
        }

}
