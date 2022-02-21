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
using System.Threading.Tasks;
using XamarinSample.Data;
using XamarinSample.DataModel;

namespace XamarinSample.Activities
{
    [Activity(Label = "StudentResultActivity")]
    public class StudentResultActivity : Activity
    {
        TextView Subject1, Subject2, Subject3, Subject4, Subject5, Total;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StudentResultScreen);
            // Create your application here
            Subject1 = FindViewById<TextView>(Resource.Id.subject1Result);
            Subject2 = FindViewById<TextView>(Resource.Id.subject2Result);
            Subject3 = FindViewById<TextView>(Resource.Id.subject3Result);
            Subject4 = FindViewById<TextView>(Resource.Id.subject4Result);
            Subject5 = FindViewById<TextView>(Resource.Id.subject5Result);
            Total = FindViewById<TextView>(Resource.Id.totalResult);
            PopulateResultAsync();
        }
        public async Task PopulateResultAsync()
        {
            string RegisterNumber = Intent.GetStringExtra("RegisterNumber");
            try
            {
                List<SubjectDataModel> student = await Database.SelectTable<SubjectDataModel>();
                var subData = student.Where(x => x.RegisterNumber == RegisterNumber).FirstOrDefault();
                if (subData != null)
                {
                    Subject1.Text = subData.Subject1;
                    Subject2.Text = subData.Subject2;
                    Subject3.Text = subData.Subject3;
                    Subject4.Text = subData.Subject4;
                    Subject5.Text = subData.Subject5;
                    Total.Text = subData.Total;
                }
            }

            catch (Exception ex)
            {
                
            }
            
            
        }

    }
}