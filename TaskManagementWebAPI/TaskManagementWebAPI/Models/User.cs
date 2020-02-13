using System;
using System.Collections.Generic;

namespace TaskManagementWebAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Usertype { get; set; }
        public string Displayname { get; set; }
    }
}
