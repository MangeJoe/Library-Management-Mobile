using OnlineLibrary.ViewModels;

namespace OnlineLibrary.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext=loginViewModel;
	}
}