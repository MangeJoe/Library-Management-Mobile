using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OnlineLibrary.DTOs;
using OnlineLibrary.Models.BookModels;
using OnlineLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineLibrary.ViewModels.BookViewModels
{
    public  class AddBookViewModel: ObservableObject
    {

        private Book book;
        private readonly BookService _bookService;

        public int Book_Id {
            get=> book.Book_Id; 
            
        }
        public string Title { 
            get=>book.Title;
            set
            { 
            if(book.Title != value)
                {
                    book.Title = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Description
        {
            get => book.Description;
            set
            {
                if (book.Description != value)
                {
                    book.Description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ISBN { 
            get=>book.ISBN;
            set 
            {
                if (book.ISBN != value)
                {
                    book.ISBN = value;
                    OnPropertyChanged();
                }
            } 
        } 

        public string Genre {
            get=>book.Genre;
            set 
            {
                if (book.Genre != value)
                {
                    book.Genre = value;
                    OnPropertyChanged();
                }
            }
        } 

        public string Edition { 
            get=>book.Edition;
            set
            {
                if(book.Edition != value)
                {
                    book.Edition = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Publisher { 
            get=>book.Publisher;
            set
            {
                if( book.Publisher != value)
                {
                    book.Publisher = value; 
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Publication_Date {
            get=>book.Publication_Date;
            set
            {
                if(book.Publication_Date != value)
                {
                    book.Publication_Date = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Availability_Status { 
            get=>book.Availability_Status;
            set
            {
                if(Availability_Status != value)
                {
                    Availability_Status = value;
                    OnPropertyChanged();
                }
            }
        } 
        public string Image
        {
            get => book.BookImage;
            set
            {
                if (book.BookImage != value)
                {
                    book.BookImage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddBookCommand { get; set; }
        public ICommand CancelCommand {  get; set; }
        

        public AddBookViewModel(BookService bookService)
        {
            _bookService = bookService;
            book = new Book();
            AddBookCommand = new AsyncRelayCommand(AddBook);
            CancelCommand = new AsyncRelayCommand(Cencel);
        }

        private async Task AddBook()
        {
            try
            {
                ResponseDTO resp= await _bookService.AddBook(book);
                if (resp != null)
                {
                    if (resp.Success)
                    {
                        await Shell.Current.DisplayAlert("Success", "Book is added Successfully", "Ok");
                        await Shell.Current.GoToAsync("..");
                    }
                }
            } catch (Exception ex)
                {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async Task Cencel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
