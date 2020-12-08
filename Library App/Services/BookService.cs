using Library_App.Models;
using Library_App.Models.ViewModels;
using Library_App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Library_App.Models.ViewModels.BookViewModel;

namespace Library_App.Services
{
    public class BookService : IBookService
    {
        IBookRepo _bookRepo;
        public BookService(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<BookList> GetBookList()
        {
            var model = new BookList();
            foreach (var book in await _bookRepo.GetAllBooks())
            {
                model.books.Add(
                    new BookViewModel
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author
                    });  
            }
            return model;
        }

        public async Task<BookList> GetReadedBooks(User user)
        {
            var model = new BookList();
            foreach (var book in await _bookRepo.GetReadedBookList(user))
            {
                model.books.Add(
                    new BookViewModel
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author
                    });
            }
            return model;
        }
    }
}
