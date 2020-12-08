using Library_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Services.Interfaces
{
    public interface IBookRepo
    {
        Task AddBook(Book book);
        Task AddListBooks(ICollection<Book> books);
        

        Book GetBookById(int id);
        IQueryable<Book> GetAllUnreadedBooks(User user);
        
        Task<ICollection<Book>> GetReadedBookList(User user);
        Task AddReadedBook(Book book, User user);
        Task RemoveBookFromReaded(Book book, User user);
    }
}
