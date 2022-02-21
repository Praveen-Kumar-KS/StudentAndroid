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
using XamarinSample.Models;

namespace XamarinSample.Adapters
{
    public class StudentList
    {
        public StudentList(string Number)
        {
           RegisterNumber = Number;
        }
        public string RegisterNumber { get; }        
    }
    public class Student 
    {
        List<SubjectDataModel> model;
        StudentList[] Lists =
        {
            new StudentList ("1234567890"),
            new StudentList ("2368238933"),
            new StudentList ("9383348484")

        };
        private StudentList[] list;

        public Student()
        {
            list = Lists;
        }

        public int StudentData
        {
            get { return list.Length; }
        }
        public StudentList this[int i]
        {
            get { return list[i]; }
        }
        
    }
}
