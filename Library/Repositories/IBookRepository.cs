using Library.Models;
using System.Collections.Generic;
using static Azure.Core.HttpHeader;

namespace Library.Repositories
{
    public interface IBookRepository
    {
        Task<Book> CreateAsync(Book book);
        Task<Book> GetByBookId(int id);
        Task<Book> GetByBookName(string title);
        Task<IEnumerable<Book>> GetAllAsync();
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveAsync();
        
    }
}
