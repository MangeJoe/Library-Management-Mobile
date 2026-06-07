using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OnlineLibrary.Models;
using OnlineLibrary.Services;
using OnlineLibrary.Views;
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
        public string _confirmPassword=string.Empty;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
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
                if (member.Membership_Id != value)
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
        public ICommand CancelCommand { get;private set; }
        public RegisterViewModel(IUserService service)
        {
            member = new Member();
            _service = service;
            RegisterCommand = new AsyncRelayCommand(RegisterUser);
            CancelCommand = new AsyncRelayCommand(CancelCreation);
            
        }

        private async Task CancelCreation()
        {
            await Shell.Current.GoToAsync(nameof(IndexPage));
        }

        private async Task RegisterUser()
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
                if (NewMember.Password != ConfirmPassword)
                {
                    await Shell.Current.DisplayAlert("error", "password do not match", "Ok");
                    return;
                }

                bool response = await _service.CreateUser(NewMember);
                if (response)
                {
                    await Shell.Current.DisplayAlert("Success", "Member is created Successfully", "Ok");
                    await Shell.Current.GoToAsync(nameof(LoginPage));
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
