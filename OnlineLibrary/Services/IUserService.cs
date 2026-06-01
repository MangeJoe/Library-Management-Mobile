
using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Services
{
    public interface IUserService
    {
        public Task<bool> CreateUser(OverallUser Ouser);
        public Task UpdateUser(int id,OverallUser Ouser);
        public Task<bool> DeleteUser(int id);
        public Task GetUserById(int id);
        public Task GetUsers();
    }
}
