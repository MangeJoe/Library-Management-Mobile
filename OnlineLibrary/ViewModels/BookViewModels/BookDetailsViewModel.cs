using CommunityToolkit.Mvvm.ComponentModel;
using OnlineLibrary.Models.BookModels;
using OnlineLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.ViewModels.BookViewModels
{
    public class BookDetailsViewModel : ObservableObject, IQueryAttributable
    {
        private Book book;
        private readonly BookService _bookService;
        public int Book_Id
        {
            get => book.Book_Id;
            set
            {
                book.Book_Id = value;
            }
        }
        public string Title
        {
            get => book.Title;
            set
            {
                if (book.Title != value)
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

        public string ISBN
        {
            get => book.ISBN;
            set
            {
                if (book.ISBN != value)
                {
                    book.ISBN = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Genre
        {
            get => book.Genre;
            set
            {
                if (book.Genre != value)
                {
                    book.Genre = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Edition
        {
            get => book.Edition;
            set
            {
                if (book.Edition != value)
                {
                    book.Edition = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Publisher
        {
            get => book.Publisher;
            set
            {
                if (book.Publisher != value)
                {
                    book.Publisher = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Publication_Date
        {
            get => book.Publication_Date;
            set
            {
                if (book.Publication_Date != value)
                {
                    book.Publication_Date = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Availability_Status
        {
            get => book.Availability_Status;
            set
            {
                if (Availability_Status != value)
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

        public BookDetailsViewModel(BookService service)
        {
            book = new Book();
            _bookService = service;
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("bookId"))
            {
                Book_Id = Convert.ToInt16(query["bookId"].ToString());
                LoadBookDetails(Book_Id);
            }
        }

        private async void LoadBookDetails(int id)
        {
            try
            {
                Book ans= await _bookService.GetBook(id);
                if (ans != null)
                {
                    Title = ans.Title;
                    Description = ans.Description;
                    ISBN=ans.ISBN;
                    Genre = ans.Genre;
                    Edition=ans.Edition;
                    Publisher=ans.Publisher;
                    Publication_Date=ans.Publication_Date;
                    Availability_Status=ans.Availability_Status;

                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("error", ex.Message, "Ok");
            }
        }
    }

}
