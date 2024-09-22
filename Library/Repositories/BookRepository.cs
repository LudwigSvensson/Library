using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);   
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByBookId(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> GetByBookName(string title)
        {
            return await _context.Books.FirstOrDefaultAsync(b=>b.Title == title.ToLower());
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
