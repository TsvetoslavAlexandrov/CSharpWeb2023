using Library.Contract;
using Library.Data;
using Library.Data.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Description = b.Description,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };

            return model;

        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = decimal.Parse(model.Rating),
                CategoryId = model.CategoryId
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook()
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await dbContext.IdentityUserBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        
    }
}
