using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace New_Note
{
    public class DatabaseLayer
    {
        //Acting as an interface betweeen app and the Database
        static Lazy<SQLiteAsyncConnection> lazy = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DBPath, Constants.Flags);
        });

        //Instantiating the Database
        public SQLiteAsyncConnection SQLiteDatabase = lazy.Value;



        //Database functions
        public void CreateNoteTable()
        {
            if (!SQLiteDatabase.TableMappings.Any(m => m.TableName == typeof(ModelTable).Name))
            {
                SQLiteDatabase.CreateTableAsync<ModelTable>();
            }
        }

        public Task<List<ModelTable>> GetNote()
        {
            return SQLiteDatabase.Table<ModelTable>().ToListAsync();
        }

        public void SaveNote(ModelTable note)
        {
            if (note.ID == 0)
            {
                SQLiteDatabase.InsertAsync(note);
            }
            else
            {
                SQLiteDatabase.UpdateAsync(note);
            }
        }

        public void DeleteNote(ModelTable note)
        {
            SQLiteDatabase.DeleteAsync(note);
        }


    }

    //Constant class no need to create another class
    public static class Constants
    {
        public const string DatabaseFilename = "NotesDB.db3";
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
