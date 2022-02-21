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
using System.Threading.Tasks;
using XamarinSample.Data;
using XamarinSample.DataModel;
using XamarinSample.Strings;

namespace XamarinSample.Activities
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : AppCompatActivity
    {
        EditText Name, register, pass, classStd, confirmPass, email;
        TextView validation;
        Button submit;
        CoordinatorLayout coordinatorLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Bidings
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterScreen); // View Call
            // Create your application here
            submit = FindViewById<Button>(Resource.Id.SubmitRegBtn);
            Name = FindViewById<EditText>(Resource.Id.nameregister);
            register = FindViewById<EditText>(Resource.Id.registerno);
            pass = FindViewById<EditText>(Resource.Id.password);
            classStd = FindViewById<EditText>(Resource.Id.classStd);
            confirmPass = FindViewById<EditText>(Resource.Id.cnfpwd);
            validation = FindViewById<TextView>(Resource.Id.ValidationMessage);
            email = FindViewById<EditText>(Resource.Id.mail);
            coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.layoutView);
            this.FindViewById<Button>(Resource.Id.SubmitRegBtn).Click += this.RegisterAsync; //Navigation through click event

        }
        public async void RegisterAsync(object sender, EventArgs e)
        {
            if(RegisterValidation() && RegisterNumberValidation() && ClassStdValidation() && EmailValidation() && await RegisterDataValidationAsync()) // Validation Check
            {               
                PopulateRegisterAsync(); // Data populate
            }
                
        }

        public async Task PopulateRegisterAsync() // Insert Operation
        {
            StudentUserDataModel studentUserDataModel = new StudentUserDataModel();
            studentUserDataModel.Name = Name.Text;
            studentUserDataModel.RegisterNumber = register.Text;
            studentUserDataModel.Password = pass.Text;
            studentUserDataModel.ClassStd = classStd.Text;
            studentUserDataModel.Email = email.Text;
            if (studentUserDataModel.Password.Equals(confirmPass.Text))
            {
                await Database.InsertIntoTable(studentUserDataModel);
                Toast.MakeText(this, "Registered Successfully...,", ToastLength.Short).Show();
                StartActivity(new Intent(Application.Context, typeof(StudentActivity)));

            }
            else
            {
                validation.Visibility = ViewStates.Visible;
                validation.Text = NameStrings.PasswordMismatch;
            }
        }

        public bool RegisterValidation() //main validation
        {
            //Regex RegisterNumberPattern = new Regex(@"^\d+$");
            //Regex ClassStdPattern = new Regex(@"^\d+$");
            //Regex EmailPattern = new Regex(@"^([a-zA-Z0-9_\-\.] +)@((\[[0-9]{ 1,3}\.[0-9]{ 1,3}\.[0-9]{ 1,3}\.)| (([a-zA-Z0-9\-] +\.)+))([a-z]{ 2,3}|[0-9]{ 1,3})(\]?)$");
            //int std = Int32.Parse(classStd.Text);
            if (string.IsNullOrEmpty(classStd.Text) && string.IsNullOrEmpty(confirmPass.Text) && string.IsNullOrEmpty(pass.Text) && string.IsNullOrEmpty(register.Text) && string.IsNullOrEmpty(Name.Text))
            {
                //validation.Visibility = ViewStates.Visible;
                Snackbar.Make(coordinatorLayout, NameStrings.Registration, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(Name.Text))
            {
                //validation.Visibility = ViewStates.Visible;
                Snackbar.Make(coordinatorLayout, NameStrings.Name, Snackbar.LengthLong).Show();
                return false;
            }
            else if(string.IsNullOrEmpty(pass.Text))
            {
                //validation.Visibility = ViewStates.Visible;
                Snackbar.Make(coordinatorLayout, NameStrings.Password, Snackbar.LengthLong).Show();
                return false;
            }
            else if(string.IsNullOrEmpty(register.Text))
            {
                //validation.Visibility = ViewStates.Visible;
                Snackbar.Make(coordinatorLayout, NameStrings.RegisterNumber, Snackbar.LengthLong).Show();
                return false;
            }
            else if(string.IsNullOrEmpty(confirmPass.Text))
            {
                //validation.Visibility = ViewStates.Visible;
                Snackbar.Make(coordinatorLayout, NameStrings.Re_Password, Snackbar.LengthLong).Show();
                return false;
            }
            else if(string.IsNullOrEmpty(classStd.Text))
            {
                //validation.Visibility = ViewStates.Visible;
                Snackbar.Make(coordinatorLayout, NameStrings.Class, Snackbar.LengthLong).Show();
                return false;
            }
            else if (string.IsNullOrEmpty(email.Text))
            {
                //validation.Visibility = ViewStates.Visible;
                Snackbar.Make(coordinatorLayout, NameStrings.Email, Snackbar.LengthLong).Show();
                return false;
            }
            //else if (RegisterNumberPattern.IsMatch(register.Text) && register.Text.Length == 10)
            //{
            //    //validation.Visibility = ViewStates.Visible;
            //    Snackbar.Make(coordinatorLayout, NameStrings.RegisterNumberValidation, Snackbar.LengthLong).Show();
            //    return false;
            //}
            //else if (ClassStdPattern.IsMatch(classStd.Text) && classStd.Text.Length == 2 && std >= 1 && std <= 12)
            //{
            //    //validation.Visibility = ViewStates.Visible;
            //    Snackbar.Make(coordinatorLayout, NameStrings.ClassStdValidation, Snackbar.LengthLong).Show();
            //    return false;
            //}
            //else if (EmailPattern.IsMatch(email.Text))
            //{
            //    //validation.Visibility = ViewStates.Visible;
            //    Snackbar.Make(coordinatorLayout, NameStrings.MailValidation, Snackbar.LengthLong).Show();
            //    return false;
            //}

            return true;
        }
          
        public bool RegisterNumberValidation() 
        {
            Regex RegisterNumberPattern = new Regex(@"^\d+$");

            if (RegisterNumberPattern.IsMatch(register.Text) && register.Text.Length == 10)
            {
                return true;
            }
            else 
            {
                Snackbar.Make(coordinatorLayout, NameStrings.RegisterNumberValidation, Snackbar.LengthLong).Show();
                return false;
            }
        }
        public bool ClassStdValidation()
        {
            Regex ClassStdPattern = new Regex(@"^\d+$");
            int std = Int32.Parse(classStd.Text);
            if (ClassStdPattern.IsMatch(classStd.Text) && classStd.Text.Length == 2 && std >= 1 && std <= 12)
            {
                return true;
            }
            else
            {
                Snackbar.Make(coordinatorLayout, NameStrings.ClassStdValidation, Snackbar.LengthLong).Show();
                return false;
            }
        }
        public bool EmailValidation()
        {
            Regex EmailPattern = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-z]{2,3}|[0-9]{1,3})(\]?)$");
            if (EmailPattern.IsMatch(email.Text))
            {
                return true;
            }
            else
            {
                Snackbar.Make(coordinatorLayout, NameStrings.MailValidation, Snackbar.LengthLong).Show();
                return false;
            }
        }
        
        public async Task<bool> RegisterDataValidationAsync() //data validation
        {
            List<StudentUserDataModel> DataModels = await Database.SelectTable<StudentUserDataModel>();
            var data = DataModels.FirstOrDefault(x => x.RegisterNumber == register.Text);
            if (data != null)
            {
                Snackbar.Make(coordinatorLayout, NameStrings.RegisterNumberExist, Snackbar.LengthLong).Show();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}