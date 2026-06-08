
using OnlineLibrary.DTOs;
using OnlineLibrary.Models.UserModels;
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
        public Task<UpdateUserDTO> UpdateUser(int id,OverallUser Ouser);
        public Task<bool> DeleteUser(int id);
        public Task<GetByIdDTO> GetUserById(int id);
        public Task<List<Member>> GetUsers();
        public Task<GetByIdDTO> Login(LoginDTO login);
    }
}
