using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SHIT.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileSystemImplementation))]
namespace SHIT.Droid
{    
    class FileSystemImplementation
    {

        public string GetExternalStorage()
        {
            Context context = Android.App.Application.Context;
            var filepath = context.GetExternalFilesDir("");
            return filepath.Path;
        }

    }
}