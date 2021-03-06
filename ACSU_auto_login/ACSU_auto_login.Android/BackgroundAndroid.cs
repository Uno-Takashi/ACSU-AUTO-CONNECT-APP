﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Net;

namespace ACSU_auto_login.Droid
{
    [Service(Name = "com.CompanyName.AppName.BackgroundService", Process = ":TestProcess")]
    public class BackgroundService : Service
    {
        private bool networkAnalyzer()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;

            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            if (isOnline)
            {
                if (networkinfoChacker(activeConnection.ExtraInfo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Xamarin.Forms.Application.Current.Properties["networkinfo"] = "NotConnect";
                return false;
            }

        }

        private bool networkinfoChacker(string networkinfomation)
        {

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey("networkinfo"))
            {
                if (Xamarin.Forms.Application.Current.Properties["networkinfo"] as string == networkinfomation)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(1000 * 60);
                    var bundle = new Bundle();
                    global::Xamarin.Forms.Forms.Init(this, bundle);
                    if (Xamarin.Forms.Application.Current.Properties.ContainsKey("background"))
                    {
                        if ((bool)Xamarin.Forms.Application.Current.Properties["background"] && networkAnalyzer())
                        {
                            System.Diagnostics.Debug.WriteLine(networkAnalyzer());
                            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

                            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;


                            Xamarin.Forms.Application.Current.Properties["networkinfo"] = activeConnection.ExtraInfo;

                            try
                            {
                                if (Xamarin.Forms.Application.Current.Properties.ContainsKey("password") && Xamarin.Forms.Application.Current.Properties.ContainsKey("id") && Xamarin.Forms.Application.Current.Properties["id"] as string != "" && Xamarin.Forms.Application.Current.Properties["password"] as string != "")
                                {
                                    ACSU_auto_login.login log = new ACSU_auto_login.login(Xamarin.Forms.Application.Current.Properties["id"] as string, Xamarin.Forms.Application.Current.Properties["password"] as string);
                                }
                                else
                                {
                                    throw new WriteException();
                                }

                                if (Xamarin.Forms.Application.Current.Properties.ContainsKey("success"))
                                {
                                    if ((bool)Xamarin.Forms.Application.Current.Properties["success"])
                                    {

                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {

                                }
                            }
                            catch (WriteException)
                            {
                                System.Diagnostics.Debug.WriteLine("Error");
                            }
                            catch (Exception)
                            {
                                System.Diagnostics.Debug.WriteLine("Error");
                            }
                        }
                        else
                        {
                            if ((bool)Xamarin.Forms.Application.Current.Properties["background"] == false)
                            {
                                Xamarin.Forms.Application.Current.Properties["networkinfo"] = "NoBackground";
                            }
                        }
                    }

                }
            });
            task.Start();

            return StartCommandResult.Sticky;
        }
        public void StartBackgroundService()
        {
            //サービスを起動する
            Intent serviceIntent = new Intent(this, typeof(BackgroundService));
            serviceIntent.AddFlags(ActivityFlags.NewTask);
            serviceIntent.SetPackage(this.PackageManager.GetPackageInfo(this.PackageName, 0).PackageName);
            base.StartService(serviceIntent);
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            //Killされてもサービスを再起動する。
            this.StartBackgroundService();
        }
    }



}