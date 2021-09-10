using New_Note.Misc;
using New_Note.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New_Note
{
    public class LocalDatabase
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
            
            if (!SQLiteAsync.TableMappings.Any(m => m.TableName == typeof(NotesModel).Name))
            {
                SQLiteAsync.CreateTableAsync<NotesModel>();
            }
        }

        //Read table
        public Task<List<NotesModel>> ReadNote()
        {
            return SQLiteAsync.Table<NotesModel>().ToListAsync();
        }

        //Update/Save table
        public void SaveNote(NotesModel note)
        {
            if (note.ID == 0)
                SQLiteAsync.InsertAsync(note);
            else
                SQLiteAsync.UpdateAsync(note);
        }

        //Delete note
        public void DeleteNote(NotesModel note)
        {
            SQLiteAsync.DeleteAsync(note);
        }
    }
}
