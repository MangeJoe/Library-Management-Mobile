using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService()
        {
            _httpClient = new()
            {
                BaseAddress= new Uri("https://localhost:7196")
            };
        }
        async Task<bool> IUserService.CreateUser(OverallUser Ouser)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/User", Ouser);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("error",ex.Message,"Ok");
                return false;
            }
           
            
        }

        async Task<bool> IUserService.DeleteUser(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/User/{id}");
                if (response.IsSuccessStatusCode)
                    return true;
                return false;
            }
            catch (Exception ex) 
            {
                await Shell.Current.DisplayAlert("error", ex.Message, "Ok");
                return false;
            }
           

        }

        Task IUserService.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        Task IUserService.GetUsers()
        {
            throw new NotImplementedException();
        }

        Task IUserService.UpdateUser(int id, OverallUser Ouser)
        {
            throw new NotImplementedException();
        }
    }
}
