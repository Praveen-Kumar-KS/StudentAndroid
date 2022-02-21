//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Support.V7.Widget;
//using Android.Views;
//using Android.Widget;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using XamarinSample.Adapters;
//using XamarinSample.Enums;
//using XamarinSample.Models;

//namespace XamarinSample.Activities
//{
//    [Activity(Label = "MainInventoryActivity")]
//    public class MainInventoryActivity : Activity
//    {
//        RecyclerView recyclerView;
//        RecyclerViewAdapter adapter;
//        public RecyclerView.LayoutManager LayoutManager;
//        public List<Inventory> list = new List<Inventory>();

//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            SetContentView(Resource.Layout.MainInventoryRecyclerScreen);
//            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
//            recyclerView.SetLayoutManager(new GridLayoutManager(this, 1));
//            LayoutManager = new LinearLayoutManager(this);  
//            adapter = new RecyclerViewAdapter(list, this);
//            recyclerView.SetAdapter(adapter);
//            InventoryData();
//        }

//        public void InventoryData()
//        {
//            list.Add(new Inventory() { Image = Resource.Drawable.rowmoveicon, Data = DataEnums.Admin });
//            list.Add(new Inventory() { Image = Resource.Drawable.rowmoveicon, Data = DataEnums.Student });
//            list.Add(new Inventory() { Image = Resource.Drawable.rowmoveicon, Data = DataEnums.StudentList });

//        }
//    }
//}