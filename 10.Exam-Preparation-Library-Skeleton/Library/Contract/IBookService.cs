using Library.ViewModels;

namespace Library.Contract
{
    public interface IBookService
    {
        Task AddBookToCollectionAsync(int bookId, string userId);
        Task<IEnumerable<ViewModelBooks>> GetAllBooksAsync();
    }
}
