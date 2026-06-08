using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models.UserModels
{
    public class Librarian: User
    {
        public DateTime HiredDate { get; set; }

        public string Shift { get; set; } = string.Empty;
    }
}
