using Library_App.Models;
using Library_App.Models.ViewModels;
using Library_App.Services.Interfaces;
using Library_App.Services.MockData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public UserManager<User> _userManager;

        private IBookRepo _bookRepo;
        private IBookService _bookService;

        public HomeController(UserManager<User> userManager, IBookRepo bookRepo, IBookService bookService)
        {
            _userManager = userManager;
            _bookRepo = bookRepo;
            _bookService = bookService;
        }

        public async Task<IActionResult> GenerateMockData()
        {
            MockData mockData = new MockData(_bookRepo);
            await mockData.CreateMockData();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = await _bookService.GetBookList(user);
            return View(model);
        }

        public async Task<IActionResult> RemoveBook(int id)
        {
            var book = _bookRepo.GetBookById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            await _bookRepo.RemoveBookFromReaded(book, user);
            return RedirectToAction("ReadedBook", "Home");
        }

        public async Task<IActionResult> ReadedBook()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = await _bookService.GetReadedBooks(user);
            return View(model);
        }

        public async Task<IActionResult> AddToReaded(int id)
        {
            var book = _bookRepo.GetBookById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            await _bookRepo.AddReadedBook(book, user);
            return RedirectToAction("ReadedBook", "Home");
        }

        public IActionResult AddBook()
        {
            return View();
        }       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            await _bookRepo.AddBook(new Book { Name = model.Name, Author = model.Author });

            return RedirectToAction("Index");
        }
    }
}
