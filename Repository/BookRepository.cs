using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class BookRepository : IBookRepository
    {
        public static List<Book> Books = new List<Book>
        {
    new Book {Id=1, title = "The Great Gatsby", ISBN = "9780743273565", price = 25.99, Author = "F. Scott Fitzgerald" },
    new Book {Id=2, title = "To Kill a Mockingbird", ISBN = "0061120081", price = 19.99, Author = "Harper Lee" },
    new Book {Id=3, title = "1984", ISBN = "9780451524935", price = 12.50, Author = "George Orwell" },
    new Book {Id=4, title = "The Catcher in the Rye", ISBN = "9780241950425", price = 15.75, Author = "J.D. Salinger" },
    new Book {Id=5, title = "The Hobbit", ISBN = "9780547928227", price = 22.95, Author = "J.R.R. Tolkien" }
            //... Vous pouvez en ajouter d'autres pour fiabiliser les résultats de vos tests
        };

        public void Create(Book book)
        {
            Books.Add(book);
        }

        public void Delete(int id)
        {
            Book livreToRemove = GetById(id);
            if (livreToRemove != null)
            {
                Books.Remove(livreToRemove);
            }
            else
            {
                throw new Exception($"Le livre avec l'ID {id} n'a pas été trouvé.");
            }
        }

        public List<Book> GetAll()
        {
            return Books;
        }

        public Book GetById(int id)
        {
            return Books.FirstOrDefault(l => l.Id == id);
        }

        public Book GetByTitre(string title)
        {
            return Books.FirstOrDefault(l => l.title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void Update(int id, Book book)
        {
            var existingLivre = GetById(id);
            if (existingLivre != null)
            {
                existingLivre.title = book.title;
                existingLivre.Author = book.Author;
                existingLivre.ISBN = book.ISBN;
                existingLivre.price = book.price;
            }
        }
    }
}
