using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Mappers
{
    public class BookMapper
    {
        //Mapper pour l'ajout
        public static Book ToModel(AddBookVM vm)
        {
            return new Book
            {
                Id = vm.Id,
                title = vm.title,
                ISBN = vm.ISBN,
                price = vm.price,
                Author = vm.Author,
            };
        }
        //Mappper pour Update
        public static void UpdateVM(UpdateBookVM vm, Book book)
        {
            book.title = vm.title;
            book.ISBN = vm.ISBN;
            book.price = vm.price;
            book.Author = vm.Author;
        }
        //Mapper Pour Lister
        public static ListBookVM ListViewModel(Book book)
        {
            return new ListBookVM
            {
                Id = book.Id,
                title = book.title,
                ISBN = book.ISBN,
                price = book.price,
                Author = book.Author,
            };
        }
        //Mapper pour delete
        public static DeleteBookVM DeleteViewModel(Book book)
        {
            return new DeleteBookVM
            {
                Id = book.Id,
                title = book.title
            };
        }
    }
}
