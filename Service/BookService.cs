using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Service
{
    public class BookService : IBooksService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Create(AddBookVM livrevm)
        {
            Book book = BookMapper.ToModel(livrevm);
            bookRepository.Create(book);
        }

        public DeleteBookVM Delete(int id)
        {
            Book book = bookRepository.GetById(id);
            if (book == null)
            {
                throw new Exception($"Le livre avec l'ID {id} n'a pas été trouvé.");
            }

            bookRepository.Delete(id);
            return BookMapper.DeleteViewModel(book);
        }

        public List<ListBookVM> GetAll()
        {
            var books = bookRepository.GetAll();
            return books.Select(BookMapper.ListViewModel).ToList();
        }

        public ListBookVM GetById(int id)
        {
            Book book = bookRepository.GetById(id);
            if (book == null) throw new Exception("Book not found");

            return BookMapper.ListViewModel(book);
        }

        public Book GetByTitre(string title)
        {
            Book book = bookRepository.GetByTitre(title);
            if (book == null)
                throw new KeyNotFoundException("Livre avec ce titre non trouvé");
            return book;
        }

        public void Update(UpdateBookVM updatevm)
        {
            Book book = bookRepository.GetById(updatevm.Id);
            if (book == null)
            {
                throw new Exception("Le livre n'a pas été trouvé");
            }

            BookMapper.UpdateVM(updatevm, book);
            bookRepository.Update(updatevm.Id, book);
        }
    }
}
