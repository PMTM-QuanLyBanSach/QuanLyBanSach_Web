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
        public ActionResult Index()
        {
            List<KhachHang> dsKH = db.KhachHang.ToList();
            return View(dsKH);
        }
    }
}