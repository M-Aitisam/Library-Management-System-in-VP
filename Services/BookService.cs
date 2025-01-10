using _230456_AitisamAhmed_vplabPaper.Models;
using Blazored.LocalStorage;

namespace _230456_AitisamAhmed_vplabPaper.Services
{

    public class BookService : IBookService
    {
        private readonly ILocalStorageService _localStorageService;
        private List<Book> books = new();
        private const string BooksKey = "BooksData";

        public BookService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task AddBookAsync(Book book)
        {
            books.Add(book);
            await SaveBooksToLocalStorageAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            await LoadBooksFromLocalStorageAsync();
            return books.FirstOrDefault(b => b.Id == id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                books.Remove(existingBook);
                books.Add(book);
                await SaveBooksToLocalStorageAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                await SaveBooksToLocalStorageAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            await LoadBooksFromLocalStorageAsync();
            return books;
        }

        public async Task SaveBooksToLocalStorageAsync()
        {
            await _localStorageService.SetItemAsync(BooksKey, books);
        }

        public async Task LoadBooksFromLocalStorageAsync()
        {
            var storedBooks = await _localStorageService.GetItemAsync<List<Book>>(BooksKey);
            books = storedBooks ?? new List<Book>();
        }
    }

}
