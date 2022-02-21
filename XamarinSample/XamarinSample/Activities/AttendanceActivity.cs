using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSample.Data;
using XamarinSample.DataModel;

namespace XamarinSample.Activities
{
    [Activity(Label = "AttendanceActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class AttendanceActivity : AppCompatActivity
    {
        EditText Name, RegNo, TotalDays, AbsentDays, PresentDays;
        Button Submit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AttendanceScreen);
            // Create your application here
            ImageButton back = FindViewById<ImageButton>(Resource.Id.btnBack);
            Name = FindViewById<EditText>(Resource.Id.input_name);
            RegNo = FindViewById<EditText>(Resource.Id.input_register);
            TotalDays = FindViewById<EditText>(Resource.Id.ttlworking);
            AbsentDays = FindViewById<EditText>(Resource.Id.absent);
            PresentDays = FindViewById<EditText>(Resource.Id.present);
            Submit = FindViewById<Button>(Resource.Id.attenSubmitBtn);
            this.FindViewById<Button>(Resource.Id.attenSubmitBtn).Click += this.AttendanceModule;
            this.FindViewById<ImageButton>(Resource.Id.btnBack).Click += this.BackNavigation;
        }
        public void BackNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(AdminInventoryActivity)));
        }
        public void AttendanceModule(object sender, EventArgs e)
        {
            PopulateAttendance();
        }

        public async Task PopulateAttendance() // Insert operation
        {
            List<StudentUserDataModel> attendanceDataModel = await Database.SelectTable<StudentUserDataModel>();
            var attendance = attendanceDataModel.FirstOrDefault(x => x.Name == Name.Text && x.RegisterNumber == RegNo.Text);
            if(attendance != null)
            {
                AttendanceDataModel attendanceData = new AttendanceDataModel();
                attendanceData.PresentDays = PresentDays.Text;
                attendanceData.TotalDays = TotalDays.Text;
                attendanceData.AbsentDays = AbsentDays.Text;
                attendanceData.UserId = attendance.Id;
                await Database.InsertIntoTable(attendanceData);
                Toast.MakeText(this, "Submitted", ToastLength.Short).Show();
                ClearText();

            }
        }
        public void ClearText()
        {
            Name.Text = "";
            RegNo.Text = "";
            PresentDays.Text = "";
            TotalDays.Text = "";
            AbsentDays.Text = "";
        }

    }
}