using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinSample.DataModel
{
    public class StudentUserDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegisterNumber { get; set; }
        public string Password { get; set; }
        public string ClassStd { get; set; }
        public string Email { get; set; }
    }
}