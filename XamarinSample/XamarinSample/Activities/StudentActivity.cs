using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSample.Data;
using XamarinSample.DataModel;
using XamarinSample.Strings;

namespace XamarinSample.Activities
{
    [Activity(Label = "StudentActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class StudentActivity : AppCompatActivity
    {
        EditText register, password;
        Button btn, registerBtn;
        TextView validation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StudentLoginScreen);
            // Create your application here
            validation = FindViewById<TextView>(Resource.Id.LoginValidationMessage);
            register = FindViewById<EditText>(Resource.Id.txtregister);
             password = FindViewById<EditText>(Resource.Id.txtpassword);
             btn = FindViewById<Button>(Resource.Id.SubmitLoginBtn);
             registerBtn = FindViewById<Button>(Resource.Id.RegisterLoginBtn);
            this.FindViewById<Button>(Resource.Id.SubmitLoginBtn).Click += this.ResultNavigation;
            this.FindViewById<Button>(Resource.Id.RegisterLoginBtn).Click += this.RegisterNavigation;
        }
        public void ResultNavigation(object sender, EventArgs e)
        {
            Login();            
        }

        public async Task Login()
        {
            List<StudentUserDataModel> studentUserDataModels = await Database.SelectTable<StudentUserDataModel>();
            var login = studentUserDataModels.Where(x => x.RegisterNumber == register.Text && x.Password == password.Text).FirstOrDefault(); //Get by ID
            if (LoginValidation())
            {
                if (login != null)
                {
                    Toast.MakeText(this, "You're in..", ToastLength.Short).Show(); 
                    Intent i = new Intent(this, typeof(StudentResultActivity));
                    i.PutExtra("RegisterNumber", register.Text.ToString());
                    StartActivity(i); // Navigation
                    //StartActivity(new Intent(Application.Context, typeof(StudentResultActivity)));
                }

                else
                {
                    validation.Visibility = ViewStates.Visible;
                    validation.Text = NameStrings.Login;
                }
            }
        }
        public void RegisterNavigation(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(RegisterActivity)));
        }
        public bool LoginValidation()
        {
            if (string.IsNullOrEmpty(register.Text) && string.IsNullOrEmpty(password.Text))
            {
                validation.Visibility = ViewStates.Visible;
                validation.Text = NameStrings.LoginCredential;
                return false;
            }
            else if (string.IsNullOrEmpty(register.Text))
            {
                validation.Visibility = ViewStates.Visible;
                validation.Text = NameStrings.Name;
                return false;
            }
            else if (string.IsNullOrEmpty(password.Text))
            {
                validation.Visibility = ViewStates.Visible;
                validation.Text = NameStrings.Password;
                return false;
            }
            return true;
        }

    }
}