using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models;

namespace QuanLyBanSach_Web.Controllers
{
    public class AccountController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(QL_NguoiDung user)
        {
            QL_NguoiDung ND =  db.QL_NguoiDung.FirstOrDefault(r => r.TenDangNhap == user.TenDangNhap && r.MatKhau == user.MatKhau);

            if (ND == null)
            {
                ModelState.AddModelError("Lỗi", "Tên đăng nhập hoặc mật khẩu sai");
                return View();
            }
                

            return RedirectToAction("Index", "Home");
        }
    }
}