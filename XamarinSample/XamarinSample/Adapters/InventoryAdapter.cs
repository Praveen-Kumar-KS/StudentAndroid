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
//using XamarinSample.Activities;
//using XamarinSample.Enums;
//using XamarinSample.Helper;
//using XamarinSample.Models;

//namespace XamarinSample.Adapters
//{
//    class RecyclerViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
//    {
//        public ImageView imageView { get; set; }
//        public TextView textView { get; set; }
//        List<Inventory> list = new List<Inventory>();
//        CardView Card;
//        TextView admin, student;
//        Context context;

//        public RecyclerViewHolder(View itemView, Activity context, List<Inventory> list) : base(itemView)
//        {
//            imageView = itemView.FindViewById<ImageView>(Resource.Id.imageViewItem);
//            textView = itemView.FindViewById<TextView>(Resource.Id.textViewItem);
//            itemView.SetOnClickListener(this);
//            CardView card = ItemView.FindViewById<CardView>(Resource.Id.card1);
//            int width = context.Resources.DisplayMetrics.WidthPixels;
//            int height = context.Resources.DisplayMetrics.HeightPixels;
//            card.LayoutParameters.Height = (height - (4 * 10 + 200)) / 4;
//            card.LayoutParameters.Width = (width - 80) / 2;
//            this.context = context;
//            this.list = list;
//        }

//        public void OnClick(View v)
//        {
//            var selectedItem = list[AdapterPosition];
//            Navigation(selectedItem.Data);
//        }

//        public void Navigation(DataEnums enmus)
//        {
//            Intent intent;
//            switch (enmus)
//            {
//                case DataEnums.Admin:
//                    intent = new Intent(this.context, typeof(AdminInventoryActivity));
//                    //intent.PutExtra("InventoryData", enmus.ToString());
//                    textView.Text = DataEnums.Admin.GetDescription();
//                    this.context.StartActivity(intent);
//                    break;
//                case DataEnums.Student:
//                    intent = new Intent(this.context, typeof(StudentActivity));
//                    //intent.PutExtra("InventoryData", enmus.ToString());
//                    textView.Text = DataEnums.Student.GetDescription();
//                    this.context.StartActivity(intent);
//                    break;
//                case DataEnums.StudentList:
//                    intent = new Intent(this.context, typeof(StudentListActivity));
//                    //intent.PutExtra("InventoryData", enmus.ToString());
//                    textView.Text = DataEnums.Student.GetDescription();
//                    this.context.StartActivity(intent);
//                    break;
//            }
//        }
//    }
//    internal class RecyclerViewAdapter : RecyclerView.Adapter
//    {

//        public List<Inventory> list;
//        public Activity context;
//        public RecyclerViewAdapter(List<Inventory> list, Activity context)
//        {

//            this.list = list;
//            this.context = context;
//        }

//        public override int ItemCount
//        {
//            get
//            {
//                return list.Count;
//            }
//        }
//        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
//        {
//            LayoutInflater inflater = LayoutInflater.From(parent.Context);
//            View itemView = inflater.Inflate(Resource.Layout.MainInventoryItem, parent, false);
//            return new RecyclerViewHolder(itemView, context, list);
//        }

//        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
//        {
//            RecyclerViewHolder holder = viewHolder as RecyclerViewHolder;
//            holder.imageView.SetImageResource(list[position].Image);
//            holder.textView.Text = list[position].Data.GetDescription();
//        }
//    }
//}