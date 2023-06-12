using Library.Contract;
using Library.Data;
using Library.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<ViewModelBooks>> GetAllBooksAsync()
        {
           return await dbContext
                .Books
                .Select(p => new ViewModelBooks()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    Rating = p.Rating,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name
                })
                .ToArrayAsync();
        }


        public Task AddBookToCollectionAsync(int bookId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
