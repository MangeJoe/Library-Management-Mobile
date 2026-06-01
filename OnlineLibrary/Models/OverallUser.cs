using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models
{
    public class OverallUser
    {
        public int UserID { get; set; }


        public string Name { get; set; } = string.Empty;


        public string Phone_Number { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Membership_Id { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int Borrow_Limit { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime HiredDate { get; set; }

        public string Shift { get; set; } = string.Empty;
        public string OfficeLocation { get; set; } = string.Empty;
    }
}
