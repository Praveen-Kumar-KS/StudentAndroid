using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XamarinSample.Helper
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class Extensions : Attribute
    {
        private readonly string description;
        public string Description { get { return description; } }
        public Extensions(string description)
        {
            this.description = description;
        }
    }
    public static class EnumsHelper
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            return v.GetCustomAttribute<T>();
        }

        public static string GetDescription(this Enum enumVal)
        {
            var attr = GetAttributeOfType<Extensions>(enumVal);
            return attr != null ? attr.Description : string.Empty;
        }
    }
}
       