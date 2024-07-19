using System.Collections.Generic;
using digiBookModel;

namespace digiBookDataLayer
{
    public static class Data
    {
        public static List<bookss> GetBooks()
        {
            sqldbdata dataAccess = new sqldbdata();
            return dataAccess.GetBooks();
        }

        public static bool AddBook(bookss book)
        {
            sqldbdata dataAccess = new sqldbdata();
            return dataAccess.AddBook(book);
        }

        public static bool UpdateBook(bookss book)
        {
            sqldbdata dataAccess = new sqldbdata();
            return dataAccess.UpdateBook(book);
        }
    }
}