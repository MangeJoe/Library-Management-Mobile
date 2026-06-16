using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OnlineLibrary.DTOs;
using OnlineLibrary.Models.BookModels;
using OnlineLibrary.Services;
using System.Windows.Input;


namespace OnlineLibrary.ViewModels.BookViewModels.BookCopyViewModels
{
    public class CopyDetailsViewModel : ObservableObject
    {

        private readonly BookService _bookService;
        private readonly BookCopy _copy;

        public int Copy_Id { get => _copy.Copy_Id; }
        public int Book_Id { get => _copy.Book_Id; }
        public string Condition
        {
            get => _copy.Condition;
            set
            {
                if (_copy.Condition != value)
                {
                    _copy.Condition = value;
                    OnPropertyChanged();

                }
            }
        }
        public string Status
        {
            get => _copy.Status;
            set
            {
                if (_copy.Status != value)
                {
                    _copy.Status = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCopyCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CopyDetailsViewModel(BookService bookService)
        {
            _bookService = bookService;
            _copy = new BookCopy();
            AddCopyCommand = new AsyncRelayCommand(AddBookCopy);
            CancelCommand = new AsyncRelayCommand(CencelCommand);
        }

        private async Task CencelCommand()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task AddBookCopy()
        {
            try
            {
                ResponseDTO resDTO = await _bookService.AddBookCopy(_copy);
                if (resDTO != null && resDTO.Success) 
                {
                    await Shell.Current.DisplayAlert("Success", "Book Copy is added successfully", "Ok");
                    await Shell.Current.GoToAsync("..");
                }
                await Shell.Current.DisplayAlert("error", "failed to add book copy", "Ok");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("error", ex.Message, "Ok");
                await Shell.Current.GoToAsync("..");

            }
        }
    }

}
