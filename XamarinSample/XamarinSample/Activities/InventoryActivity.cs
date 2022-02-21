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
    [Activity(Label = "InventoryActivity")]
    public class InventoryActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainInventoryScreen);
            // Create your application here
            Button admin = FindViewById<Button>(Resource.Id.adminInbtn);
            Button student = FindViewById<Button>(Resource.Id.studentInbtn);

            this.FindViewById<Button>(Resource.Id.adminInbtn).Click += this.AdminNavigation;
            this.FindViewById<Button>(Resource.Id.studentInbtn).Click += this.StudentNavigation;
        }
        public void AdminNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(AdminInventoryActivity)));
        }
        public void StudentNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(StudentActivity)));
        }
    }
}