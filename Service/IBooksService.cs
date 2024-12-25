using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Service
{
    public interface IBooksService
    {
        List<ListBookVM> GetAll();
        ListBookVM GetById(int id);
        Book GetByTitre(string title);
        void Create(AddBookVM livrevm);
        void Update(UpdateBookVM updatevm);
        DeleteBookVM Delete(int id);
    }
}
