using WebApplication1.Models;
using WebApplication1.Repository;
using Xunit;

namespace WebApplication1.Test
{
    public class BooksTest
    {
        private BookRepository bookRepository;

        public BooksTest()
        {
            bookRepository = new BookRepository();
        }
        [Fact]
        public void GetAll_RetourneTousLesLivres()
        {
            // Act
            var books = bookRepository.GetAll();

            // Assert
            Assert.NotNull(books);
            Assert.Equal(6, books.Count);
        }
        [Fact]
        public void GetById_ShouldReturnCorrectBook()
        {
            // Act
            var book = bookRepository.GetById(1);

            // Assert
            Assert.NotNull(book);
            Assert.Equal("The Great Gatsby", book.title);
        }

        [Fact]
        public void Create()
        {
            // Arrange
            var newbook = new Book
            {
                Id = 6,
                title = " Hobbit",
                ISBN = "47928227",
                price = 22.5,
                Author = "Tolkien"
            };

            // Act
            bookRepository.Create(newbook);
            var livres = bookRepository.GetAll();

            // Assert
            Assert.Equal(6, livres.Count);
            Assert.Contains(newbook, livres);
        }
        [Fact]
        public void GetByTitre_ShouldReturnCorrectBook()
        {
            // Act
            var book = bookRepository.GetByTitre("1984");

            // Assert
            Assert.NotNull(book);
            Assert.Equal("1984", book.title);
        }
        [Fact]
        public void Update_ShouldModifyExistingBook()
        {
            // Arrange
            var updatedBook = new Book
            {
                title = "Updated Title",
                ISBN = "Updated ISBN",
                price = 30.00,
                Author = "Updated Author"
            };

            // Act
            bookRepository.Update(1, updatedBook);

            // Assert
            var book = bookRepository.GetById(1);
            Assert.NotNull(book);
            Assert.Equal("Updated Title", book.title);
            Assert.Equal("Updated ISBN", book.ISBN);
            Assert.Equal(30.00, book.price);
            Assert.Equal("Updated Author", book.Author);
        }
    }
}
