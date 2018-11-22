using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace ACSU_auto_login
{
    class acsu_login_component
    {
        class MyInfo
        {
            public string id;
            public string password;
            public MyInfo() { }
            public MyInfo(string id, string password)
            {
                this.id = id;
                this.password = password;
            }

            public void set_id(string id)
            {
                this.id = id;
            }
            public void set_password(string password)
            {
                this.password = password;
            }

            public string get_id()
            {
                return this.id;
            }
            public string get_password()
            {
                return this.password;
            }
        }
        public class ACSU
        {
            public Uri POST_url = new Uri("https://acsu.shinshu-u.ac.jp/ActiveCampus/module/Login.php");
            public Uri After_url = new Uri("https://login.shinshu-u.ac.jp/cgi-bin/Login.cgi");

        }
        class Program
        {
            static void Main(string[] args)
            {
                MyInfo myinfo = new MyInfo();
                myinfo.set_id("15t5801g");
                myinfo.set_password("tenipuri");
                string param = "mode=Login&clickcheck=0&login=" + myinfo.get_id() + "&passwd=" + myinfo.get_password();
                byte[] data = Encoding.ASCII.GetBytes(param);

                ACSU acsu = new ACSU();

                CookieContainer cc = new CookieContainer();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(acsu.POST_url.ToString());
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;
                req.CookieContainer = cc;
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                //レスポンスの取得
                WebResponse res = req.GetResponse();
                Stream resStream = res.GetResponseStream();

                Encoding encoder = Encoding.GetEncoding("UTF-8");
                StreamReader sr = new StreamReader(resStream, encoder);
                string result = sr.ReadToEnd();
                sr.Close();
                resStream.Close();

                param = "uid=" + myinfo.get_id() + "&pwd=" + myinfo.get_password();
                data = Encoding.ASCII.GetBytes(param);
                //HTTP GET リクエストの作成
                req = (HttpWebRequest)WebRequest.Create(acsu.After_url.ToString());
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;
                req.CookieContainer = cc;
                reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                //レスポンスの取得
                res = req.GetResponse();
                resStream = res.GetResponseStream();

                encoder = Encoding.GetEncoding("UTF-8");
                sr = new StreamReader(resStream, encoder);
                result = sr.ReadToEnd();
                sr.Close();
                resStream.Close();
                Console.WriteLine(result);

            }
        }
    }
}
