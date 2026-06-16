using OnlineLibrary.ViewModels.BookViewModels;

namespace OnlineLibrary.Views.BookPages;

public partial class BookDetailsPage : ContentPage
{
	public BookDetailsPage(BookDetailsViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}