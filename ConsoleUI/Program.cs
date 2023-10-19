using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookManager bookManager = new BookManager(new EfBookDal());
            

            foreach (var book in bookManager.GetBookDetails())
            {
                
                Console.WriteLine(book.BookName + " " + book.CategoryName + " "+ book.AuthorFirstName + " " + book.AuthorLastName);
            }

            

        }
    }
}