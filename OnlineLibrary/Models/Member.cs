using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models
{
    public class Member
    {
        public int UserId { get; set; }
        public string Membership_Id { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int Borrow_Limit { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
