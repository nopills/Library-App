using Library_App.Models;
using Library_App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Services
{
    public class BookRepo : IBookRepo
    {
        private DatabaseContext _db;
        public BookRepo(DatabaseContext db)
        {
            _db = db;
        }

        public async Task AddBook(Book book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
        }

  
        public async Task AddListBooks(ICollection<Book> books)
        {
            _db.AddRange(books);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Book>> GetAllBooks()
        {
           return await _db.Books.ToListAsync();
        } 

        public Book GetBookById(int id)
        {
            return _db.Books.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Book> GetBookByName(string name)
        {
            return _db.Books.Where(x => x.Name.Contains(name));
        }

        public async Task<ICollection<Book>> GetReadedBookList(User user)
        {
            return await _db.Books.Where(x => x.ReadedByUser.Contains(user)).ToListAsync();
        }

        public async Task RemoveBookFromReaded(Book book, User user)
        {
            _db.Books.Include(x => x.ReadedByUser).FirstOrDefault(x => x.Id == book.Id).ReadedByUser.Remove(user);
            await _db.SaveChangesAsync();
        }
        public async Task AddReadedBook(Book book, User user)
        {
            _db.Books.Include(x => x.ReadedByUser).FirstOrDefault(x => x.Id == book.Id).ReadedByUser.Add(user);

            await _db.SaveChangesAsync();
        }

    }
}
