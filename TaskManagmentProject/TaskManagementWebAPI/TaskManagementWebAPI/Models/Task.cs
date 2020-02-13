using System;
using System.Collections.Generic;

namespace TaskManagementWebAPI.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Taskdetail { get; set; }
        public int Statusid { get; set; }
        public string Taskheading { get; set; }
        public string Username { get; set; }
    }
}
