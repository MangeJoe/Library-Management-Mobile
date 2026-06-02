using OnlineLibrary.DTOs;
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
            catch
            {
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

        async Task<GetByIdDTO> IUserService.GetUserById(int id)
        {

           return  await _httpClient.GetFromJsonAsync<GetByIdDTO>($"/api/User/{id}");
           
        }

        async Task<List<Member>> IUserService.GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<Member>>("/api/User");
        }

        async Task<GetByIdDTO> IUserService.Login(string membershipId, string password)
        {
           
                LoginDTO login = new()
                {
                    Membership_Id = membershipId,
                    Password = password
                };
                var response = await _httpClient.PostAsJsonAsync("/api/User/Login", login);
            if (response.IsSuccessStatusCode)
            {
                var newResponse=await response.Content.ReadFromJsonAsync<GetByIdDTO>();
                if (newResponse != null)
                {
                    GetByIdDTO responseDTO = new()
                    {
                        Id = newResponse.Id
                    };
                    return responseDTO;
                }
                return new GetByIdDTO()
                {
                    Id = 0
                };
            }
            return new GetByIdDTO()
            {
                Id = 0
            };


        }

        async Task<UpdateUserDTO> IUserService.UpdateUser(int id, OverallUser Ouser)
        {

            
                var response = await _httpClient.PutAsJsonAsync($"/api/User/{id}", Ouser);
                if (response.IsSuccessStatusCode)
                {
                    var contentResp = await response.Content.ReadFromJsonAsync<UpdateUserDTO>();
                    if (contentResp != null)
                    {
                        UpdateUserDTO updateUserDTO = new()
                        {
                            Id = contentResp.Id,
                            Success = contentResp.Success,
                        };

                        return updateUserDTO;
                    }
                    return new UpdateUserDTO()
                    {
                        Id = 0,
                        Success =false,
                    }; 
                }
                return new UpdateUserDTO()
                {
                    Id = 0,
                    Success = false,
                };
           
        }
    }
}
