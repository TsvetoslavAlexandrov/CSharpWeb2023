using Library.Contract;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{

    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService; 
        }

        public async Task<IActionResult> All()
        {
            var allBooks = await _bookService.GetAllBooksAsync();

            return View(allBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel addBooks = await _bookService.GetNewAddBookModelAsync();

            return View(addBooks);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;
            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10.");

                return View(model);
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await _bookService.AddBookAsync(model);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await _bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }
        //public async Task<IActionResult> AddToCollection(int id)
        //{
        //    var book = await bookService.GetBookByIdAsync(id);

        //    if (book == null)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    var userId = GetUserId();

        //    await bookService.AddBookToCollectionAsync(userId, book);

        //    return RedirectToAction(nameof(All));
        //}
    }
}
