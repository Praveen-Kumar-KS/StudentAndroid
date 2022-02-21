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

namespace XamarinSample.Activities
{
    [Activity(Label = "AdminInventoryActivity")]
    public class AdminInventoryActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AdminInventoryScreen);
            // Create your application here
            Button result = FindViewById<Button>(Resource.Id.resultInBtn);
            Button atten = FindViewById<Button>(Resource.Id.attendancebtn);

            this.FindViewById<Button>(Resource.Id.resultInBtn).Click += this.ResultNavigation;
            this.FindViewById<Button>(Resource.Id.attendancebtn).Click += this.AttendanceNavigation;
        }
        public void ResultNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(ResultActivity)));
        }
        public void AttendanceNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(AttendanceActivity)));
        }
    }
}