using OnlineLibrary.ViewModels.BookViewModels;

namespace OnlineLibrary.Views.BookPages;

public partial class AddBookPage : ContentPage
{
	public AddBookPage(AddBookViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}