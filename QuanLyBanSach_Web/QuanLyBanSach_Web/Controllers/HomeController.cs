using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models;

namespace QuanLyBanSach_Web.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: Home
        public ActionResult Index(int page = 1, string search = "")
        {
            List<Sach> books = db.Sach.Where(t => t.TenSach.Contains(search)).ToList();
            ViewBag.Search = search;

            //Paging
            int NoRecordPerPage = 8;
            int NoPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(books.Count) / Convert.ToDouble(NoRecordPerPage)));
            int NoRecordToSkip = (page - 1) * NoRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoPages = NoPage;
            books = books.Skip(NoRecordToSkip).Take(NoRecordPerPage).ToList();

            return View(books);
        }

        public ActionResult Detail(string id)
        {
            Sach book = db.Sach.Where(t => t.MaSach == id).FirstOrDefault();

            if (book == null)
                return RedirectToAction("/Index");

            return View(book);
        }

        public ActionResult DanhMuc(int page = 1, string id = "")
        {
            List<Sach> books = db.Sach.Where(t => t.MaDanhMuc == id).ToList();

            //Paging
            int NoRecordPerPage = 8;
            int NoPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(books.Count) / Convert.ToDouble(NoRecordPerPage)));
            int NoRecordToSkip = (page - 1) * NoRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoPages = NoPage;
            books = books.Skip(NoRecordToSkip).Take(NoRecordPerPage).ToList();

            return View(books);
        }
    }
}