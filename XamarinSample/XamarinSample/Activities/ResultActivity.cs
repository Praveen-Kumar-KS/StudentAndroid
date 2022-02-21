using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XamarinSample.Data;
using XamarinSample.DataModel;
using XamarinSample.Strings;

namespace XamarinSample.Activities
{
    [Activity(Label = "ResultActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class ResultActivity : AppCompatActivity
    {
        Button submit, atten;
        EditText studentName, registerNumber, sub1, sub2, sub3, sub4, sub5, total;
        CoordinatorLayout coordinatorLayout;
        //TextView total;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ResultScreen);
            // Create your application here
            submit = FindViewById<Button>(Resource.Id.resultSubmitBtn);
            atten = FindViewById<Button>(Resource.Id.attenNavBtn);

            studentName = FindViewById<EditText>(Resource.Id.name_text);
            registerNumber = FindViewById<EditText>(Resource.Id.regNo_text);
            sub1 = FindViewById<EditText>(Resource.Id.sub_text1);
            sub2 = FindViewById<EditText>(Resource.Id.sub_text2);
            sub3 = FindViewById<EditText>(Resource.Id.sub_text3);
            sub4 = FindViewById<EditText>(Resource.Id.sub_text4);
            sub5 = FindViewById<EditText>(Resource.Id.sub_text5);
            total = FindViewById<EditText>(Resource.Id.total_text);
            coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.listViewSnack);
            ImageButton back = FindViewById<ImageButton>(Resource.Id.btnBack);
            this.FindViewById<ImageButton>(Resource.Id.btnBack).Click += this.BackNavigation;
            this.FindViewById<Button>(Resource.Id.resultSubmitBtn).Click += this.Submit;
            this.FindViewById<Button>(Resource.Id.attenNavBtn).Click += this.AttendanceNavigation;
            ShowDataAsync();
            //DeleteDataAsync();
        }
        public void AttendanceNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(AttendanceActivity)));
        }
        public void BackNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(AdminInventoryActivity)));
        }
        public void Submit(object sender, EventArgs e)
        {
            ResultData();

        }
        public async Task ResultData()
        {
            List<StudentUserDataModel> StudentsDataModels = await Database.SelectTable<StudentUserDataModel>();
            var studentId = StudentsDataModels.FirstOrDefault(x => x.Name == studentName.Text && x.RegisterNumber == registerNumber.Text);
            List<SubjectDataModel> subData = await Database.SelectTable<SubjectDataModel>();
            var data = subData.FirstOrDefault(x => x.Name == studentName.Text && x.RegisterNumber == registerNumber.Text);
            if(Validate() && RegisterNumberValidation() && SubjectValidation() && TotalEntryValidation() && await DataRegisterValidationAsync())
            {
                if (studentId != null)
                {
                    SubjectDataModel subject = new SubjectDataModel();
                    if (data == null)
                    {
                        subject.Id = studentId.Id;
                        subject.Name = studentName.Text;
                        subject.RegisterNumber = registerNumber.Text;
                        subject.Subject1 = sub1.Text;
                        subject.Subject2 = sub2.Text;
                        subject.Subject3 = sub3.Text;
                        subject.Subject4 = sub4.Text;
                        subject.Subject5 = sub5.Text;
                        subject.Total = total.Text;
                        subject.UserId = studentId.Id;
                        await Database.InsertIntoTable(subject);
                        Toast.MakeText(this, "Submitted", ToastLength.Short).Show();
                        ClearText();
                    }
                    else
                    {
                        subject.Id = data.Id;
                        subject.Name = studentName.Text;
                        subject.RegisterNumber = registerNumber.Text;
                        subject.Subject1 = sub1.Text;
                        subject.Subject2 = sub2.Text;
                        subject.Subject3 = sub3.Text;
                        subject.Subject4 = sub4.Text;
                        subject.Subject5 = sub5.Text;
                        subject.Total = total.Text;
                        subject.UserId = studentId.Id;
                        await Database.UpdateById(subject);
                        Toast.MakeText(this, "Submitted", ToastLength.Short).Show();
                        ClearText();
                    }
                }
            }            
        }

        public void ClearText()
        {
            studentName.Text = "";          
            registerNumber.Text = "";
            sub1.Text = "";
            sub2.Text = "";
            sub3.Text = "";
            sub4.Text = "";
            sub5.Text = "";
            total.Text = "";
        }
        public async Task ShowDataAsync()
        {
            string RegisterNumber = Intent.GetStringExtra("RegisterListNumber");
            List<SubjectDataModel> DataModels = await Database.SelectTable<SubjectDataModel>();
            var model = DataModels.FirstOrDefault(x => x.RegisterNumber == RegisterNumber);
            studentName.Text = model.Name;
            registerNumber.Text = model.RegisterNumber;
            sub1.Text = model.Subject1;
            sub2.Text = model.Subject2;
            sub3.Text = model.Subject3;
            sub4.Text = model.Subject4;
            sub5.Text = model.Subject5;
            total.Text = model.Total;
        }
        //public async Task DeleteDataAsync()
        //{
        //    string RegisterNumber = Intent.GetStringExtra("RegisterListNumber");
        //    List<SubjectDataModel> DataModels = await Database.SelectTable<SubjectDataModel>();
        //    var model = DataModels.FirstOrDefault(x => x.RegisterNumber == RegisterNumber);
        //    var data = await Database.DeleteTable<SubjectDataModel>(model);
        //}
        public bool Validate()
        {
            if(string.IsNullOrEmpty(studentName.Text) && string.IsNullOrEmpty(registerNumber.Text) && string.IsNullOrEmpty(sub1.Text) && string.IsNullOrEmpty(sub2.Text)
                && string.IsNullOrEmpty(sub3.Text) && string.IsNullOrEmpty(sub4.Text) && string.IsNullOrEmpty(sub5.Text) && string.IsNullOrEmpty(total.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.Result, Snackbar.LengthLong).Show();
                return false;
            }
            else if(string.IsNullOrEmpty(studentName.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.NameResult, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(registerNumber.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.RegisterResult, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(sub1.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.subject_1, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(sub2.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.subject_2, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(sub3.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.subject_3, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(sub4.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.subject_4, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(sub5.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.subject_5, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(total.Text))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.subjectTotal, Snackbar.LengthLong).Show();
                return false;
            }
            return true;
        }
        public bool RegisterNumberValidation()
        {
            Regex RegisterNumberPattern = new Regex(@"^\d+$");

            if (RegisterNumberPattern.IsMatch(registerNumber.Text) && registerNumber.Text.Length == 10)
            {
                return true;
            }
            else
            {
                Snackbar.Make(coordinatorLayout, NameStrings.RegisterNumberValidation, Snackbar.LengthLong).Show();
                return false;
            }
        }
        public bool SubjectValidation()
        {
            int subject1 = Int32.Parse(sub1.Text);
            int subject2 = Int32.Parse(sub2.Text);
            int subject3 = Int32.Parse(sub3.Text);
            int subject4 = Int32.Parse(sub4.Text);
            int subject5 = Int32.Parse(sub5.Text);
            if (!(subject1 >= 0 && subject1 <= 100))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.Sub_Data, Snackbar.LengthLong).Show();
                return false;
            }
            else if(!(subject2 >= 0 && subject2 <= 100))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.Sub_Data, Snackbar.LengthLong).Show();
                return false;
            }
            else if (!(subject3 >= 0 && subject3 <= 100))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.Sub_Data, Snackbar.LengthLong).Show();
                return false;
            }
            else if (!(subject4 >= 0 && subject4 <= 100))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.Sub_Data, Snackbar.LengthLong).Show();
                return false;
            }
            else if (!(subject5 >= 0 && subject5 <= 100))
            {
                Snackbar.Make(coordinatorLayout, NameStrings.Sub_Data, Snackbar.LengthLong).Show();
                return false;
            }
            return true;
        }
        public bool TotalEntryValidation()
        {
            int totalsub = Int32.Parse(total.Text);
            if (totalsub >= 0 && totalsub <= 500)
            {
                return true;
            }
            else
            {
                Snackbar.Make(coordinatorLayout, NameStrings.Sub_Data, Snackbar.LengthLong).Show();
                return false;
            }
        }
        
        public async Task<bool> DataRegisterValidationAsync()
        {
            List<StudentUserDataModel> DataModels = await Database.SelectTable<StudentUserDataModel>();
            var data = DataModels.FirstOrDefault(x => x.RegisterNumber == registerNumber.Text && x.Name == studentName.Text);
            if (data == null)
            {
                Snackbar.Make(coordinatorLayout, NameStrings.RegisterData_and_NameData, Snackbar.LengthLong).Show();
                return false;
            }
            else 
            {
                return true;
            }
        }
        //public async Task<bool> DataNameValidationAsync()
        //{
        //    List<StudentUserDataModel> DataModels = await Database.SelectTable<StudentUserDataModel>();
        //    var data = DataModels.FirstOrDefault(x => x.Name == studentName.Text);
        //    if (data == null)
        //    {
        //       Snackbar.Make(coordinatorLayout, NameStrings.RegisterNumberData, Snackbar.LengthLong).Show();
        //       return false;
        //    }
        //    else
        //    {
        //       return true;
        //    }
            
        //}
    }
}
