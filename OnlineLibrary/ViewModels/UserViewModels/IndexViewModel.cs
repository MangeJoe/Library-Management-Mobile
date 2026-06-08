using OnlineLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.ViewModels.UserViewModels
{
    public class IndexViewModel : IQueryAttributable
    {
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("userId"))
            {
                GetByIdDTO getByIdDTO = new()
                {
                    Id = Convert.ToInt32(query["userId"].ToString())
                };
            }
        }
    }
}
