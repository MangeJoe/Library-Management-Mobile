using CommunityToolkit.Mvvm.ComponentModel;
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
    public class RegisterViewModel : ObservableObject
    {
        private Member member;
        private readonly IUserService _service;
        public string Name { 
            
            get=> member.Name;

            set
            {
                if (member.Name != value)
                {
                    member.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Phone_Number
        {

            get => member.Phone_Number;

            set
            {
                if (member.Phone_Number != value)
                {
                    member.Phone_Number = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {

            get => member.Email;
            set
            {
                if (member.Email != value)
                {
                    member.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password { 
            
            get=>member.Password; 
            set {
                if(member.Password != value)
                {
                    member.Password = value;
                    OnPropertyChanged();
                }
            } 
        } 

        public DateTime CreatedAt
        {
            get => member.CreatedAt;
            set
            {
                if (member.CreatedAt != value)
                {
                    member.CreatedAt = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Membership_Id
        {
            get => member.Membership_Id;
            set
            {
                if(member.Membership_Id != value)
                {
                    member.Membership_Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get => member.Address;
            set
            {
                if (member.Address != value)
                {
                    member.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Borrow_Limit
        {
            get => member.Borrow_Limit;
            set
            {
                if (member.Borrow_Limit != value)
                {
                    member.Borrow_Limit = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Status
        {
            get => member.Status;
            set
            {
                if (member.Status != value)
                {
                    member.Status = value;
                    OnPropertyChanged();
                }
            }
        }



        public ICommand RegisterCommand { get;private set; }
        public RegisterViewModel(IUserService service)
        {
            member = new Member();
            _service = service;
            RegisterCommand = new AsyncRelayCommand(Register);
        }

        private async Task Register()
        {
            OverallUser NewMember = new()
            {
                Name = Name,
                Phone_Number = Phone_Number,
                Email = Email,
                Password = Password,
                CreatedAt= CreatedAt,
                Membership_Id=Membership_Id,
                Address = Address,
                Borrow_Limit= Borrow_Limit,
                Status = Status,
            };
            try
            {
                bool response = await _service.CreateUser(NewMember);
                if (response)
                {
                    await Shell.Current.DisplayAlert("Success", "Member is created Successfully", "Ok");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Failed to create a Member", "Ok");
                }
            }
            catch(Exception ex) 
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            

        }
    }
}
