using CommunityToolkit.Mvvm.Input;
using OnlineLibrary.Models;
using OnlineLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineLibrary.ViewModels
{
    public class LoginViewModel
    {
        private readonly IUserService _service;
        private Member member;
        
        public string Membership_Id {get=>member.Membership_Id;}
        public string Password { get=>member.Password; }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IUserService service)
        {
            _service = service;
            member = new Member();
            LoginCommand = new AsyncRelayCommand(Login);
        }

        private async Task Login()
        {
            
        }
    }
}
