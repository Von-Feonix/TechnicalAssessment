using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TechnicalAssessment.Models;

namespace TechnicalAssessment.DAL
{
    public class BookstoreContext : DbContext 
    {

        public BookstoreContext() : base("BookstoreContext") { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}