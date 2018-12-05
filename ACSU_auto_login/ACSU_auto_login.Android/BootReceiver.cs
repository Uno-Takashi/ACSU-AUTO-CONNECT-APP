using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Threading.Tasks;
using Android.Net;

namespace ACSU_auto_login.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted,
                      "android.intent.action.QUICKBOOT_POWERON",
                      "com.htc.intent.action.QUICKBOOT_POWERON",
                      "android.intent.action.PACKAGE_INSTALL",
                      "android.intent.action.PACKAGE_ADDED",
                      Intent.ActionMyPackageReplaced　//,
                      //Intent.ActionPackageReplaced
})]
    public class BootReceiver : BroadcastReceiver
    {
        public BootReceiver() : base()
        {
        }
        public override void OnReceive(Context context, Intent intent)
        {
            Intent serviceIntent = new Intent(context, typeof(BackgroundService));
            serviceIntent.AddFlags(ActivityFlags.NewTask);
            serviceIntent.SetPackage(context.PackageManager.GetPackageInfo(context.PackageName, 0).PackageName);
            context.StartService(serviceIntent);
        }
    }
}