using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using System.Windows.Forms;
using TechnicalAssessment.DAL;
using TechnicalAssessment.Models;
using MessageBox = System.Windows.Forms.MessageBox;
using MessageBoxOptions = System.Windows.Forms.MessageBoxOptions;

namespace TechnicalAssessment.Controllers
{
    public class BooksController : Controller
    {
        private BookstoreContext db = new BookstoreContext();

        // GET: Books
        public ActionResult Index(string searchString)
        {
            var books = from b in db.Books select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.bookName.Contains(searchString));
            }
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,bookName,bookID,reserved")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,bookName,bookID,reserved")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }




        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }



        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Reserve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else if (book.reserved == true)
            {
                MessageBox.Show("This book has been reserved!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (book.reserved == false)
            {
                book.reserved = true;
                db.Entry(book).State = EntityState.Modified;
                Reservation reservation = new Reservation();
                reservation.Book = book;
                reservation.reservationTime = DateTime.Now.ToString();
                db.Reservations.Add(reservation);
                db.SaveChanges();
                string bookingNumber = "\n Your booking number is: " + db.Reservations.Count().ToString();
                
                MessageBox.Show("Reservation successful!"+bookingNumber, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve([Bind(Include = "ID,bookName,bookID,reserved")] Book book)
        {
            if (ModelState.IsValid)
            {

                if (book.reserved == true)
                {
                    MessageBox.Show("This book has been reserved!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                else if (book.reserved == false)
                {
                    book.reserved = true;
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(book);
        }
        */

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else if (book.reserved == false)
            {
                MessageBox.Show("This book has been returned!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (book.reserved == true)
            {
                book.reserved = false;
                db.Entry(book).State = EntityState.Modified;

                db.SaveChanges();
                MessageBox.Show("Return successful!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return([Bind(Include = "ID,bookName,bookID,reserved")] Book book)
        {
            if (ModelState.IsValid)
            {

                if (book.reserved == false)
                {
                    MessageBox.Show("This book has been returned!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                }
                else if (book.reserved == true)
                {
                    book.reserved = false;
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(book);
        }
        */


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
