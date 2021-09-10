using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace New_Note.Misc
{
    public class Constants
    {
        public static bool IsLoggedIn { get; set; }
        public static string NotesCount { get; set; }

        public static string FirebaseDatabaseURL = "https://notes-84ec0-default-rtdb.firebaseio.com/";
        public static string WebApiKey = "AIzaSyCpA3ZyO-eUorPIpcXb0PxGVeJLquVscSA";

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

        public static string email = Preferences.Get("Usermail", "pa7407071463@gmail.com");
        static string[] colors = new string[20];
        static Random r = new Random();
        public Constants()
        {
            setColors();
        }
        public static string setColors()
        {
            colors[0] = "#eccc68";
            colors[1] = "#ff7f50";
            colors[2] = "#ff6b81";
            colors[3] = "#7bed9f";
            colors[4] = "#70a1ff";
            colors[5] = "#5352ed";
            colors[6] = "#1e90ff";
            colors[7] = "#2ed573";
            colors[8] = "#2d98da";
            colors[9] = "#a55eea";
            colors[10] = "#3867d6";
            colors[11] = "#34e7e4";
            colors[12] = "#0fbcf9";
            colors[13] = "#ff3f34";
            colors[14] = "#F8EFBA";
            colors[15] = "#F97F51";
            colors[16] = "#55E6C1";
            colors[17] = "#D6A2E8";
            colors[18] = "#55E6C1";
            colors[19] = "#25CCF7";

            return colors[r.Next(0, 19)];
        }
        public static async Task<PermissionStatus> CheckAndRequestStoragePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            return status;
        }
    }
}