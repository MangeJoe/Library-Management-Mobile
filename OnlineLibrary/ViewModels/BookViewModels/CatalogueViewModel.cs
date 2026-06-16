using CommunityToolkit.Mvvm.Input;
using OnlineLibrary.Models.BookModels;
using OnlineLibrary.Services;
using OnlineLibrary.Views.BookPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineLibrary.ViewModels.BookViewModels
{
    public class CatalogueViewModel: IQueryAttributable
    {
        public BookService _bookService;
        public ObservableCollection<BookDetailsViewModel> allBooks {  get; set; }
        public ICommand AddNewBookCommand { get; set; }
        public ICommand BookDetailsCommand { get; set; }

        public CatalogueViewModel(BookService bookService)
        {
            _bookService = bookService;
            allBooks=new ObservableCollection<BookDetailsViewModel>();
            AddNewBookCommand = new AsyncRelayCommand(AddNewBook);
            BookDetailsCommand = new AsyncRelayCommand<BookDetailsViewModel>(GoToDetails);

        }

        private async Task GoToDetails(BookDetailsViewModel? model)
        {
            await Shell.Current.GoToAsync($"{nameof(BookDetailsPage)}?bookId={model.Book_Id}");
        }

        private async Task AddNewBook()
        {
            await Shell.Current.GoToAsync(nameof(AddBookPage));
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
        }
    }
}
