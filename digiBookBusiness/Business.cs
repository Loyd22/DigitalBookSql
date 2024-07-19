using System.Collections.Generic;
using digiBookModel;
using digiBookDataLayer;

namespace digiBookBusiness
{
    public class Business
    {
        public List<bookss> GetAllBooks()
        {
            return Data.GetBooks();
        }

        public bool AddBook(string title, string author, string summary)
        {
            return Data.AddBook(new bookss { title = title, author = author, summary = summary });
        }

        public bool UpdateBook(string title, string author, string summary)
        {
            return Data.UpdateBook(new bookss { title = title, author = author, summary = summary });
        }
    }
}