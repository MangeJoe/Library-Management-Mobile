using OnlineLibrary.ViewModels;

namespace OnlineLibrary.Views;

public partial class RegisterPage : ContentPage
{

	public RegisterPage(RegisterViewModel regViewModel)
	{
		InitializeComponent();
		BindingContext=regViewModel;
	}


}