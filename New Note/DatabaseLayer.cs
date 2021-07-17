using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace New_Note
{
    public class Database
    {
        static Lazy<SQLiteAsyncConnection> lazy = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DBPath, Constants.Flags);
        });
        //Instantiating the Database
        public SQLiteAsyncConnection SQLiteAsync = lazy.Value;


        //Create table
        public void Createtable()
        {
            if (!SQLiteAsync.TableMappings.Any(m => m.TableName == typeof(Table2).Name))
            {
                SQLiteAsync.CreateTableAsync<Table2>();
            }
        }

        //Read table
        public Task<List<Table2>> ReadNote()
        {
            return SQLiteAsync.Table<Table2>().ToListAsync();
        }

        //Update/Save table
        public void SaveNote(Table2 note)
        {
            if (note.ID == 0)
                SQLiteAsync.InsertAsync(note);
            else
                SQLiteAsync.UpdateAsync(note);
        }

        //Delete note
        public void DeleteNote(Table2 note)
        {
            SQLiteAsync.DeleteAsync(note);
        }
    }

    //Constants class
    public static class Constants
    {
        public const string DatabaseFilename = "NoteDB.db3";
        public const SQLite.SQLiteOpenFlags Flags =
       // open the database in read/write mode
       SQLite.SQLiteOpenFlags.ReadWrite |
       // create the database if it doesn't exist
       SQLite.SQLiteOpenFlags.Create |
       // enable multi-threaded database access
       SQLite.SQLiteOpenFlags.SharedCache;

        public static string DBPath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }

}
