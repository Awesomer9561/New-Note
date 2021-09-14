using SQLite;
using System.Collections.Generic;

namespace New_Note.Models
{
    public class UserModel
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
