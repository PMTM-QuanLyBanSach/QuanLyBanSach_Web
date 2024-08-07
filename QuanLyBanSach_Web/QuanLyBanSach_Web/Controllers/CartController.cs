using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models;

namespace QuanLyBanSach_Web.Controllers
{
    public class CartController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: Cart
        public ActionResult Index()
        {
            List<GioHang> Carts = db.GioHang.ToList();

            return View(Carts);
        }
        public ActionResult Add(string id = "")
        {
            if (id != "")
            {
                GioHang CartsItem = db.GioHang.Where(Carts => Carts.MaSach == id).FirstOrDefault();
                if (CartsItem != null)
                {
                    CartsItem.SoLuong += 1;
                }
                else
                {
                    GioHang Carts = new GioHang();
                    Carts.MaSach = id;
                    Carts.SoLuong = 1;
                    Carts.Sach = db.Sach.Where(t => t.MaSach == id).FirstOrDefault();
                    db.GioHang.Add(Carts);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateQuantity(int quan = 0, string proid = "")
        {
            if (quan > 0)
            {
                GioHang CartsItem = db.GioHang.Where(Carts => Carts.MaSach == proid).FirstOrDefault();
                if (CartsItem != null)
                {
                    CartsItem.SoLuong = quan;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            GioHang cart = db.GioHang.Where(row => row.Sach.MaSach == id).FirstOrDefault();

            return View(cart);
        }
        [HttpPost]
        public ActionResult Delete(string id, GioHang cart)
        {
            cart = db.GioHang.Where(row => row.Sach.MaSach == id).FirstOrDefault();
            db.GioHang.Remove(cart);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}