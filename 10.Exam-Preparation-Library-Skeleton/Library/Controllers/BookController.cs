using Library.Contract;
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

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {

            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _bookService.AddBookToCollectionAsync(bookId, userId);

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong. Please try again!");
            }
            return RedirectToAction(nameof(All));

        }


    }
}
