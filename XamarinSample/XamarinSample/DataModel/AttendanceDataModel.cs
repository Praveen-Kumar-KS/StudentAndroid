using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinSample.DataModel
{
    public class AttendanceDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TotalDays { get; set; }
        public string PresentDays { get; set; }
        public string AbsentDays { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string RegisterNumber { get; set; }




    }
}