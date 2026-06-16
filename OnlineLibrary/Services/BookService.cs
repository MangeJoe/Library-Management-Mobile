using OnlineLibrary.DTOs;
using OnlineLibrary.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Services
{
    public class BookService
    {
        private HttpClient _httpClient;

        public BookService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7196")
            };
        }

        public async Task<ResponseDTO> AddBook(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Book", book);
            if (response.IsSuccessStatusCode)
            {
                var SecondResponse = await response.Content.ReadFromJsonAsync<ResponseDTO>();
                if (SecondResponse != null && SecondResponse.Success)
                {
                    return new ResponseDTO
                    {
                        Success = true,
                        Message = SecondResponse.Message
                    };
                }
            }
            return new ResponseDTO
            {
                Success = false,
                Message = "failed to Create Book"
            };
        }

        public async Task<ResponseDTO> UpdateBook(Book book)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Book", book);
            if (response.IsSuccessStatusCode)
            {
                var secResponse= await response.Content.ReadFromJsonAsync<ResponseDTO>();
                if(secResponse != null && secResponse.Success )
                {
                    return new ResponseDTO
                    {
                        Success = true,
                        Message = secResponse.Message
                    };
                }
            }
            return new ResponseDTO
            {
                Success = true,
                Message = "Failed to Update book details"
            };
        }

        public async Task<ResponseDTO> DeleteBook(int bookId)
        {
            var response = await _httpClient.DeleteAsync($"/api/Book{bookId}");
            if (response.IsSuccessStatusCode)
            {
                var newResp= await response.Content.ReadFromJsonAsync<ResponseDTO>();
                if(newResp != null && newResp.Success )
                {
                    return new ResponseDTO
                    {
                        Success = true,
                        Message = newResp.Message
                    };
                }
            }
            //if there was an error whill deleting the book
            return new ResponseDTO
            {
                Success = false,
                Message = "failed to delete book"
            };
        }

        public async Task<List<Book>> GetCatalogueOfBooks()
        {
            var Booklist=await _httpClient.GetFromJsonAsync<List<Book>>("/api/Book");
            //if the list is empty just return a new empty list
            if (Booklist == null)
                return new List<Book>();
            //else return the returned list
            return Booklist;
        }

        public async Task<Book?> GetBook(int bookId)
        {
            var response = await _httpClient.GetFromJsonAsync<Book>($"/api/Book{bookId}");
            if (response != null)
            {
                return response;
            }
            return null;
        }

        ///////////////////////////////////////--Book_Copy--////////////////////////////////////////////////////////////////

        public async Task<ResponseDTO> AddBookCopy(BookCopy book)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/BookCopy", book);
            if (response.IsSuccessStatusCode)
            {
                var SecondResponse = await response.Content.ReadFromJsonAsync<ResponseDTO>();
                if (SecondResponse != null && SecondResponse.Success)
                {
                    return new ResponseDTO
                    {
                        Success = true,
                        Message = SecondResponse.Message
                    };
                }
            }
            return new ResponseDTO
            {
                Success = false,
                Message = "failed to Create BookCopy"
            };
        }

        public async Task<ResponseDTO> UpdateBookCopy(BookCopy book)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/BookCopy", book);
            if (response.IsSuccessStatusCode)
            {
                var secResponse = await response.Content.ReadFromJsonAsync<ResponseDTO>();
                if (secResponse != null && secResponse.Success)
                {
                    return new ResponseDTO
                    {
                        Success = true,
                        Message = secResponse.Message
                    };
                }
            }
            return new ResponseDTO
            {
                Success = true,
                Message = "Failed to Update book Copy details"
            };
        }

        public async Task<ResponseDTO> DeleteBookCopy(int bookId)
        {
            var response = await _httpClient.DeleteAsync($"/api/BookCopy{bookId}");
            if (response.IsSuccessStatusCode)
            {
                var newResp = await response.Content.ReadFromJsonAsync<ResponseDTO>();
                if (newResp != null && newResp.Success)
                {
                    return new ResponseDTO
                    {
                        Success = true,
                        Message = newResp.Message
                    };
                }
            }
            //if there was an error whill deleting the book
            return new ResponseDTO
            {
                Success = false,
                Message = "failed to delete book Copy"
            };
        }

        public async Task<List<BookCopy>> ListOfBookCopies()
        {
            var Booklist = await _httpClient.GetFromJsonAsync<List<BookCopy>>("/api/BookCopy");
            //if the list is empty just return a new empty list
            if (Booklist == null)
                return new List<BookCopy>();
            //else return the returned list
            return Booklist;
        }
    }
}
