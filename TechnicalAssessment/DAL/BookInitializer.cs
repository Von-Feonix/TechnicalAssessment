using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TechnicalAssessment.Models;

namespace TechnicalAssessment.DAL
{
    public class BookInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<BookstoreContext> 
    {
        protected override void Seed(BookstoreContext context)
        {
            var books = new List<Book>
            {
                new Book{ID=1,bookName="CQRS for Dummies",bookID="9b0896fa-3880-4c2e-bfd6-925c87f22878",reserved=false},
                new Book{ID=2,bookName="Visual Studio Tips",bookID="0550818d-36ad-4a8d-9c3a-a715bf15de76",reserved=false},
                new Book{ID=3,bookName="NHibernate Cookbook",bookID="8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1",reserved=false}
            };
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
        }
    }
}