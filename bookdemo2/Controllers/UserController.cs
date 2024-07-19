using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using digiBookBusiness;
using digiBookModel;

namespace bookdemos2.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly Business _business;

        public BookController()
        {
            _business = new Business();
        }

        [HttpGet]
        public IEnumerable<bookss> GetBooks()
        {
            var books = _business.GetAllBooks();

            List<bookss> bookList = new List<bookss>();

            foreach (var book in books)
            {
                bookList.Add(new bookss
                {
                    title = book.title,
                    author = book.author,
                    summary = book.summary
                });
            }

            return bookList;
        }

        [HttpPost]
        public JsonResult AddBook([FromBody] bookss request)
        {
            var result = _business.AddBook(request.title, request.author, request.summary);
            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateBook([FromBody] bookss request)
        {
            var result = _business.UpdateBook(request.title, request.author, request.summary);
            return new JsonResult(result);
        }
    }
}
