using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models.BookModels
{
    public class BookCopy
    {
        public int Copy_Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Book_Id { get; set; } //this is the foreign key 

    }
}
