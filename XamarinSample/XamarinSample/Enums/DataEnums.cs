using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XamarinSample.Enums
{
    public enum DataEnums
    {
        [Description("ADMIN")]
        Admin = 0,
        [Description("STUDENTS")]
        Student = 1,
        [Description("STUDENTS LIST")]
        StudentList = 2,
    }
}