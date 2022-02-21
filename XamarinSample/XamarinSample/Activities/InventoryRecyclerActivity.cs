using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinSample.Adapters;
using XamarinSample.Enums;

namespace XamarinSample.Activities
{
    [Activity(Label = "InventoryRecyclerActivity")]
    public class InventoryRecyclerActivity : Activity
    {
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        RecyclerAdapter adapter;
        InventoryItem list;
        private Context context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainInventoryRecyclerScreen);
            list = new InventoryItem();
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            adapter = new RecyclerAdapter(list);
            adapter.ItemClick += OnItemClick;
            recyclerView.SetAdapter(adapter);

            void OnItemClick(object sender, int position)
            {
                Intent intent;
                var data = position + 1;
                switch(data)
                {
                    case 1:
                        StartActivity(new Intent(Application.Context, typeof(AdminInventoryActivity)));
                        break;
                    case 2:
                        StartActivity(new Intent(Application.Context, typeof(StudentActivity)));
                        break;
                    case 3:
                        StartActivity(new Intent(Application.Context, typeof(StudentListActivity)));
                        break;
                }
            }
        }        
    }

    public class RecyclerListHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }

        public RecyclerListHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageViewItem);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textViewItem);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }

    public class RecyclerAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        InventoryItem lists;

        public RecyclerAdapter(InventoryItem recyclerList)
        {
            lists = recyclerList;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
            Inflate(Resource.Layout.MainInventoryItem, parent, false);
            RecyclerListHolder holder = new RecyclerListHolder(itemView, OnClick);
            return holder;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerListHolder hold = holder as RecyclerListHolder;
            hold.Image.SetImageResource(lists[position].ImageId);
            hold.Caption.Text = lists[position].Caption;
        }
        public override int ItemCount
        {
            get { return lists.Inventory; }
        }
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }


}