using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSample.Adapters;
using XamarinSample.Data;
using XamarinSample.DataModel;
using XamarinSample.Models;

namespace XamarinSample.Activities
{
    [Activity(Label = "StudentListActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class StudentListActivity : AppCompatActivity
    {
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        StudentListAdapter adapter;
        Button Edit, Delete;
        public List<StudentUserDataModel> commonViewModels = new List<StudentUserDataModel>();        
        private Activity context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StudentList);
            PopulateData();
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewList);
            layoutManager = new LinearLayoutManager(this);
            Edit = FindViewById<Button>(Resource.Id.editList);
            Delete = FindViewById<Button>(Resource.Id.deleteList);
            recyclerView.SetLayoutManager(layoutManager);
            RefreshListAsync();
        }

        public async Task PopulateData()
        {
            List<SubjectDataModel> data = await Database.SelectTable<SubjectDataModel>();
            adapter = new StudentListAdapter(data.ToList(), this);
            recyclerView.SetAdapter(adapter);
        }
        public async Task RefreshListAsync()
        {
            List<SubjectDataModel> data = await Database.SelectTable<SubjectDataModel>();
            data.Clear();
            adapter.NotifyDataSetChanged();
        }

}       
}