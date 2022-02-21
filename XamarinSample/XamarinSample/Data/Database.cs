using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSample.DataModel;

namespace XamarinSample.Data
{
    public class Database
    {
        //static SQLiteAsyncConnection db;
        //public static async Task Data()
        //{
        //    if (db != null)
        //        return;
        //    var databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "SampleXamarin.db");
        //    db = new SQLiteAsyncConnection(databasePath);
        //    await db.CreateTableAsync<StudentUserDataModel>();
        //}

        public static string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
        public const string databaseName = "Xamarin.db";
        public static string databasePath = Path.Combine(folder, databaseName);
        public static bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(databasePath))
                {
                    connection.CreateTable<StudentUserDataModel>();
                    connection.CreateTable<SubjectDataModel>();
                    connection.CreateTable<AttendanceDataModel>();

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public static async Task<int> InsertIntoTable<T>(T obj) where T : class
        {
            try
            {
                var connection = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), databaseName));
                return await connection.InsertAsync(obj);
                
            }
            catch (SQLiteException ex)
            {
                return 0;
            }
        }
        public static async Task<int> AllInsertIntoTable<T>(IEnumerable<T> obj) where T : class
        {
            try
            {
                var connection = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), databaseName));
                return await connection.InsertAllAsync(obj);
                
            }
            catch (SQLiteException ex)
            {
                return 0;
            }
        }


        public static async Task<int> UpdateById<T>(T obj) where T : class
        {
            try
            {
                var connection = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), databaseName));
                return await connection.UpdateAsync(obj);
               
            }
            catch (SQLiteException ex)
            {
                return 0;
            }
        }

        public static async Task<int> DeleteTable<T>(T obj) where T : class
        {
            try
            {
                var connection = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), databaseName));
                return await connection.DeleteAsync(obj);
                
            }
            catch (SQLiteException ex)
            {
                return 0;
            }
        }

        public static async Task<int> DeleteAllTable<T>() where T : class
        {
            try
            {
                var connection = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), databaseName));
                return await connection.DeleteAllAsync<T>();
                

            }
            catch (SQLiteException ex)
            {
                return 0;
            }
        }
        public static async Task<List<T>> SelectTable<T>() where T : new()
        {
            var connection = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), databaseName));
            return await connection.Table<T>().ToListAsync();

            
        }

        public static async Task<T> GetById<T>(int id) where T : new()
        {
            var connection = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), databaseName));
            return await connection.FindAsync<T>(id);
            
        }
    }
}