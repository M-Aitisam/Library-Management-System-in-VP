using _230456_AitisamAhmed_vplabPaper.Models;

namespace _230456_AitisamAhmed_vplabPaper.Services
{
    public interface IBookService
    {
        Task AddBookAsync(Book book);
        Task<Book> GetBookByIdAsync(int id);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task SaveBooksToLocalStorageAsync(); // New method
        Task LoadBooksFromLocalStorageAsync(); // New method
    }
}
