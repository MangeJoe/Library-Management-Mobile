using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Models
{
    public class Manager:User
    {
        public string OfficeLocation { get; set; } = string.Empty;
    }
}
