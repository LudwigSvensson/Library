using Library.Models.DTO_s;

namespace LibraryFE.Services
{
    public interface IBookService
    {

        Task<T> GetAllBooks<T>();

        Task<T> GetBookById<T>(int id);

        Task<T> CreateBookAsync<T>(BookDTO bookDto);

        Task<T> UpdateBookAsync<T>(BookDTO bookDto);

        Task<T> DeleteBookAsync<T>(int id);
    }
}
