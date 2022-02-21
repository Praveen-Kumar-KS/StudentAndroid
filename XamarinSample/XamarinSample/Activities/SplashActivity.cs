using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinSample.Data;
using System.Threading.Tasks;
using XamarinSample.Enums;

namespace XamarinSample.Activities
{
    [Activity(Label = "SampleXamarinNew", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        DataEnums dataItem;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Database.CreateDatabase();
            SetContentView(Resource.Layout.SplashScreen);
        }
        protected override async void OnResume()
        {
            base.OnResume();
            await SimulateStartup();
        }

        async Task SimulateStartup()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            StartActivity(new Intent(Application.Context, typeof(InventoryRecyclerActivity)));
        }
    }
}