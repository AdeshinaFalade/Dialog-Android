using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using System;
using AlertDialog = Android.App.AlertDialog;

namespace Assignment_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var button = FindViewById<AppCompatButton>(Resource.Id.btnAdd);

          //  submit = FindViewById<AppCompatButton>(Resource.Id.appCompatButton1);
            button.Click += delegate {
                ShowDialog();
            };
        }

        private void ShowDialog()
        {

            View dialogView = LayoutInflater.Inflate(Resource.Layout.alert_layout, null);
            AlertDialog alertDialog;
            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Add Account");
            var submit = dialogView.FindViewById<AppCompatButton>(Resource.Id.appCompatButton1);
            dialog.SetView(dialogView);
            dialog.SetCancelable(false);
            submit.Click += (o,e) => { Toast.MakeText(this, "Added Successfully", ToastLength.Long).Show(); };
            dialog.SetNegativeButton("Close", (sender, e) => { Log.Debug("debug", "close clicked"); });
            alertDialog = dialog.Create();
            alertDialog.Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}