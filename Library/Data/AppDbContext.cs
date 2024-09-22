using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(

                new Book
                {   BookId = -1,              
                    Title = "Den hemliga historien",
                    Author = "Donna Tartt",
                    BookGenre = Book.Genre.Deckare,
                    RealeseYear = new DateTime(1992, 1, 1)
                },
                new Book
                {
                    BookId = -2,
                    Title = "Steve Jobs",
                    Author = "Walter Isaacson",
                    BookGenre = Book.Genre.Biografi,
                    RealeseYear = new DateTime(2011, 1, 1)
                },
                new Book
                {  
                    BookId = -3,
                    Title = "Stolthet och fördom",
                    Author = "Jane Austen",
                    BookGenre = Book.Genre.Romantik,
                    RealeseYear = new DateTime(1813, 1, 1)
                },
                new Book
                {
                    BookId = -4,
                    Title = "Sagan om ringen",
                    Author = "J.R.R. Tolkien",
                    BookGenre = Book.Genre.Fantasy,
                    RealeseYear = new DateTime(1954, 1, 1)
                },
                new Book
                {               
                    BookId = -5,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    BookGenre = Book.Genre.Scifi,
                    RealeseYear = new DateTime(1965, 1, 1)
                },
                new Book
                {               
                    BookId = -6,
                    Title = "Min historia",
                    Author = "Michelle Obama",
                    BookGenre = Book.Genre.Självbiografi,
                    RealeseYear = new DateTime(2018, 1, 1)
                },
                new Book
                {               
                    BookId = -7,
                    Title = "Brott och straff",
                    Author = "Fjodor Dostojevskij",
                    BookGenre = Book.Genre.Deckare,
                    RealeseYear = new DateTime(1866, 1, 1)
                },
                new Book
                {               
                    BookId = -8,
                    Title = "Alexander Hamilton",
                    Author = "Ron Chernow",
                    BookGenre = Book.Genre.Biografi,
                    RealeseYear = new DateTime(2004, 1, 1)
                },
                new Book
                {       
                    BookId = -9,
                    Title = "Anna Karenina",
                    Author = "Leo Tolstoy",
                    BookGenre = Book.Genre.Romantik,
                    RealeseYear = new DateTime(1877, 1, 1)
                },
                new Book
                {            
                    BookId = -10,
                    Title = "Harry Potter och De Vises Sten",
                    Author = "J.K. Rowling",
                    BookGenre = Book.Genre.Fantasy,
                    RealeseYear = new DateTime(1997, 1, 1)
                },
                new Book
                {                
                    BookId = -11,
                    Title = "Neuromancer",
                    Author = "William Gibson",
                    BookGenre = Book.Genre.Scifi,
                    RealeseYear = new DateTime(1984, 1, 1)
                },
                new Book
                {            
                    BookId = -12,
                    Title = "Jag är Malala",
                    Author = "Malala Yousafzai",
                    BookGenre = Book.Genre.Självbiografi,
                    RealeseYear = new DateTime(2013, 1, 1)
                },
                new Book
                {                
                    BookId = -13,
                    Title = "Morden på Rue Morgue",
                    Author = "Edgar Allan Poe",
                    BookGenre = Book.Genre.Deckare,
                    RealeseYear = new DateTime(1841, 1, 1)
                },
                new Book
                {       
                    BookId = -14,
                    Title = "Churchill: Walking with Destiny",
                    Author = "Andrew Roberts",
                    BookGenre = Book.Genre.Biografi,
                    RealeseYear = new DateTime(2018, 1, 1)
                },
                new Book
                {            
                    BookId = -15,
                    Title = "Borta med vinden",
                    Author = "Margaret Mitchell",
                    BookGenre = Book.Genre.Romantik,
                    RealeseYear = new DateTime(1936, 1, 1)
                },
                new Book
                {            
                    BookId = -16,
                    Title = "Hobbit: En oväntad resa",
                    Author = "J.R.R. Tolkien",
                    BookGenre = Book.Genre.Fantasy,
                    RealeseYear = new DateTime(1937, 1, 1)
                });
        }
    }
}
