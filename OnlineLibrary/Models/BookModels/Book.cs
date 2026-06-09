using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models.BookModels
{
    public class Book
    {

        public int Book_Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Edition { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime Publication_Date { get; set; } = DateTime.Now;
        public string Availability_Status { get; set; } = string.Empty;

        public string BookImage {  get; set; } = string.Empty;
    }
}
