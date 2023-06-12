using Library.ViewModels;

namespace Library.Contract
{
    public interface IBookService
    {
        Task<IEnumerable<ViewModelBooks>> GetAllBooksAsync();
    }
}
