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
using System.Threading.Tasks;
using XamarinSample.Activities;
using XamarinSample.Data;
using XamarinSample.DataModel;

namespace XamarinSample.Adapters
{
    public class StudentListAdapter : RecyclerView.Adapter
    {
        public event EventHandler<StudentListAdapterClickEventArgs> ItemClick;
        public List<SubjectDataModel> subjectDataModels = new List<SubjectDataModel>();
        public Activity context;
        //StudentListActivity StudentListActivity;
        public StudentListAdapter(List<SubjectDataModel> DataModels, Activity context/*, StudentListActivity StudentListActivity*/)
        {
            this.subjectDataModels = DataModels;
            this.context = context;
            //this.StudentListActivity = StudentListActivity;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.StudentListItem, parent, false);
            var vh = new StudentListAdapterViewHolder(itemView, subjectDataModels, OnClick, this.context/*, StudentListActivity*/);
            return vh;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            StudentListAdapterViewHolder holder = viewHolder as StudentListAdapterViewHolder;
            string registerName = subjectDataModels[position].RegisterNumber;
            string name = subjectDataModels[position].Name;
            holder.RegisterNumber.Text = subjectDataModels[position].RegisterNumber;
            holder.Name.Text = subjectDataModels[position].Name;
        }
        public override int ItemCount
        {
            get
            {
                return subjectDataModels.Count;
            }
        }
        void OnClick(StudentListAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        public class StudentListAdapterViewHolder : RecyclerView.ViewHolder
        {
            public TextView RegisterNumber { get; set; }
            public TextView Name { get; set; }
            public List<SubjectDataModel> Models = new List<SubjectDataModel>();
            public Button edit, delete;
            string Register;
            //StudentListActivity StudentListActivity;
            public StudentListAdapterViewHolder(View itemview, List<SubjectDataModel> subjectDataModels, Action<StudentListAdapterClickEventArgs> clickListner, Activity context/*, StudentListActivity StudentListActivity*/) : base(itemview)
            {
                RegisterNumber = itemview.FindViewById<TextView>(Resource.Id.textViewRegister);
                Name = itemview.FindViewById<TextView>(Resource.Id.textViewName);
                this.Models = subjectDataModels;
                //this.StudentListActivity = StudentListActivity;
                edit = itemview.FindViewById<Button>(Resource.Id.editList);
                delete = itemview.FindViewById<Button>(Resource.Id.deleteList);
                edit.Click += (sender, e) =>
                {
                    Register = subjectDataModels[Position].RegisterNumber;
                    Intent intent = new Intent(context, typeof(ResultActivity));
                    intent.PutExtra("RegisterListNumber", Register);
                    context.StartActivity(intent);
                };
                delete.Click += async (sender, e) =>
                {
                    Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(context);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Delete");
                    alert.SetMessage("Are you sure want to delete this data?");
                    alert.SetButton("Yes", async (c, ev) =>
                    {
                        Register = subjectDataModels[Position].RegisterNumber;
                        List<SubjectDataModel> DataModels = await Database.SelectTable<SubjectDataModel>();
                        var model = DataModels.FirstOrDefault(x => x.RegisterNumber == Register);
                        var data = await Database.DeleteTable<SubjectDataModel>(model);
                        //StudentListActivity.RefreshListAsync();
                    });
                    alert.SetButton2("No", (c, ev) => { });
                    alert.Show();
                };
            }
        }
    }
    public class StudentListAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}