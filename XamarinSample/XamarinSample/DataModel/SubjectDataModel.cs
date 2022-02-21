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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace XamarinSample.DataModel
{
    public class SubjectDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string Subject4 { get; set; }
        public string Subject5 { get; set; }
        public string Total { get; set; }
        public string Name { get; set; }
        public string RegisterNumber { get; set; }
        public int UserId { get; set; }
    }
}