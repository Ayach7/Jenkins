using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        Book GetByTitre(string title);
        void Create(Book book);
        void Update(int id, Book book);
        void Delete(int id);
    }
}
