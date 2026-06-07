
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OnlineLibrary.DTOs;
using OnlineLibrary.Models;
using OnlineLibrary.Services;
using OnlineLibrary.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineLibrary.ViewModels
{
    public class LoginViewModel:ObservableObject
    {
        private readonly IUserService _service;
        private Member member;

        public string MemberId = "";
        public string Membership_Id { get => MemberId; 
            set
            {
                if (MemberId != value)
                {
                    MemberId = value;
                    OnPropertyChanged();
                }
            }
       }
        public string _Password=string.Empty;
        public string Password { 
            get => _Password;
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SignInCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public LoginViewModel(IUserService service)
        {
            _service = service;
            member = new Member();
            SignInCommand = new AsyncRelayCommand(Login);
            CancelCommand = new AsyncRelayCommand(CancelLogin);
        }

        private async Task CancelLogin()
        {
              await Shell.Current.GoToAsync(nameof(IndexPage));
        }

        private async Task Login()
        {
            LoginDTO loginDTO = new LoginDTO
            {
                Membership_Id = MemberId,
                Password = _Password,
            };
            try
            {
                GetByIdDTO getByIdDTO = await _service.Login(loginDTO);

                if (getByIdDTO != null && getByIdDTO.Id != 0)
                {
                    await Shell.Current.GoToAsync($"{nameof(IndexPage)}?userId={getByIdDTO.Id}");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("error", "password or membershipId is incorrect", "Ok");

            }



        }
    }

}
