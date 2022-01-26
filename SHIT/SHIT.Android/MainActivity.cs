using System;

using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;



using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xfx;

namespace SHIT.Droid
{
    [Activity(Label = "НГК", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const int myPermissionsReceiptStorage = 100;

        
        protected override void OnStart()
        {

           

            base.OnStart();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            int ReceiptPerm=0;
            string storagePerm = Android.Manifest.Permission_group.Storage;


        

         

            
            Rg.Plugins.Popup.Popup.Init(this);

            XfxControls.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int RequestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(RequestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(RequestCode, permissions, grantResults);
        }
    }
}