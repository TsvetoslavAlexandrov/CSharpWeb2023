using Library.Contract;
using Library.Data;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Services;
namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService; 
        }

        [HttpPost]
        private async Task<IActionResult> All()
        {
            IEnumerable<ViewModelBooks> allBooks =
                await this._bookService.GetAllBooksAsync();

            return View(allBooks);
        }

        
    }
}
