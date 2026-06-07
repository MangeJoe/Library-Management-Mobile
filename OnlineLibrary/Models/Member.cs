using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models
{
    public class Member :User
    {
        Random rand =new Random();
        public string Membership_Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public int Borrow_Limit { get; set; } = 10;

        public string Status { get; set; } = "Active";


      public Member()
        {
            Membership_Id= "226"+rand.Next(10,100);
        }
    }
}
