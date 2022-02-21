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
using XamarinSample.Enums;

namespace XamarinSample.Adapters
{
    public class InventoryList
    {
        public InventoryList(int id, string caption)
        {
            ImageId = id;
            Caption = caption;
        }
        public int ImageId { get; }
        public string Caption { get; }
    }
    
    public class InventoryItem
    {
        static InventoryList[] InventoryLists =
        {
            new InventoryList (Resource.Drawable.rowmoveicon, DataEnums.Admin.ToString()),
            new InventoryList (Resource.Drawable.rowmoveicon,  DataEnums.Student.ToString()),
            new InventoryList (Resource.Drawable.rowmoveicon,  DataEnums.StudentList.ToString())
        };
        private InventoryList[] InList;

        public InventoryItem()
        {
            InList = InventoryLists;
        }

        public int Inventory
        {
            get { return InList.Length; }
        }
        public InventoryList this[int i]
        {
            get { return InList[i]; }
        }


    }
}