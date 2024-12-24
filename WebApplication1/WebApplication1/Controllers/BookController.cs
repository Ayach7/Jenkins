using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BookController(IBooksService booksService)
        {
            this.booksService = booksService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var livres = booksService.GetAll();  // Récupère tous les livres de la liste
            return Ok(livres);
        }


        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            try
            {
                var book = booksService.GetById(id);
                return Ok(book);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpGet("titre/{titre}")]
        public ActionResult<Book> GetByTitre(string titre)
        {
            try
            {
                var livre = booksService.GetByTitre(titre);
                return Ok(livre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] AddBookVM livrevm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    booksService.Create(livrevm);
                    return CreatedAtAction(nameof(GetById), new { id = livrevm.ISBN }, livrevm);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(new { Message = ex.Message });
                }
            }
            return UnprocessableEntity();
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateBookVM updatevm)
        {
            if (ModelState.IsValid)
            {
                updatevm.Id = id;
                booksService.Update(updatevm);
                return NoContent();
            }
            return UnprocessableEntity();


        }

        // DELETE: api/livres/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var deletedBook = booksService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
