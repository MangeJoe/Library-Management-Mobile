using OnlineLibrary.ViewModels.UserViewModels;

namespace OnlineLibrary.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext=loginViewModel;
	}

    private async void SignUpTapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}