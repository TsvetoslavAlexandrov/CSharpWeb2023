using Library.ViewModels;

namespace Library.Contract
{
    public interface IBookService
    {
        Task<AddBookViewModel> GetNewAddBookModelAsync();

        Task<IEnumerable<ViewModelBooks>> GetAllBooksAsync();

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task AddBookAsync(AddBookViewModel viewModelBook);

        Task AddBookToCollectionAsync(string userId, BookViewModel book);
    }
}
