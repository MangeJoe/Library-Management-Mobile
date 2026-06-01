using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models
{
    public class User
    {
        
        public int UserID { get; set; }

     
        public string Name { get; set; } = string.Empty;

      
        public string Phone_Number { get; set; } = string.Empty;

        
        public string Email { get; set; } = string.Empty;

        
        public string Password { get; set; } = string.Empty;

       
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
