using DoAnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class AdminController : Controller
    {
        DataClasses1DataContext db=new DataClasses1DataContext();
        public ActionResult IndexAdmin()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap","Home");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/Home_admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Home_admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Home_admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin/Home_admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Home_admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin/Home_admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult IndexKhachHang()
        {
            List<KHACHHANG> data =db.KHACHHANGs.ToList();
            return View(data);
        }
        public ActionResult IndexThuongHieu()
        {
            List<THUONGHIEUXE> data = db.THUONGHIEUXEs.ToList();
            return View(data);
        }
        public ActionResult IndexNhaCC()
        {
            List<NHACUNGCAP> data = db.NHACUNGCAPs.ToList();
            return View(data);
        }
        public ActionResult danhMucXe()
        {
            List<XEMAY> data = db.XEMAYs.ToList();
            return View(data);
        }
        public ActionResult CreateLX()
        {
            return View();
        }

        // POST: admin/Khachhang/Create
        [HttpPost]
        public ActionResult CreateLX(LOAIXE collection)
        {
            try
            {
                db.LOAIXEs.InsertOnSubmit(collection);
                db.SubmitChanges();
                return RedirectToAction("IndexLoaiXe");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Khachhang/Edit/5
        public ActionResult EditLX(string id)
        {

            var customer = db.LOAIXEs.Single(x => x.MALOAIXE == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditLX(string id, LOAIXE kh)
        {
            try
            {
                // TODO: Add update logic here
                LOAIXE nd = db.LOAIXEs.Single(x => x.MALOAIXE == id);
                nd.TENLOAIXE = kh.TENLOAIXE;
                db.SubmitChanges();
                return RedirectToAction("IndexLoaiXe");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteLX(string id)
        {
            var customer = db.LOAIXEs.Single(x => x.MALOAIXE == id);
            return View(customer);
        }

        // POST: admin/Khachhang/Delete/5
        [HttpPost]
        public ActionResult DeleteLX(string id, LOAIXE kh)
        {
            try
            {
                // TODO: Add delete logic here
                var data = db.LOAIXEs.Single(x => x.MALOAIXE == id);
                db.LOAIXEs.DeleteOnSubmit(data);
                db.SubmitChanges();
                return RedirectToAction("IndexLoaiXe");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateTH()
        {
            return View();
        }

        // POST: admin/Khachhang/Create
        [HttpPost]
        public ActionResult CreateTH(THUONGHIEUXE collection)
        {
            try
            {
                db.THUONGHIEUXEs.InsertOnSubmit(collection);
                db.SubmitChanges();
                return RedirectToAction("IndexTHUONGHIEU");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Khachhang/Edit/5
        public ActionResult EditTH(string id)
        {

            var customer = db.THUONGHIEUXEs.Single(x => x.MATHUONGHIEU == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditTH(string id, THUONGHIEUXE kh)
        {
            try
            {
                // TODO: Add update logic here
                THUONGHIEUXE nd = db.THUONGHIEUXEs.Single(x => x.MATHUONGHIEU == id);
                nd.TENTHUONGHIEU = kh.TENTHUONGHIEU;
                db.SubmitChanges();
                return RedirectToAction("IndexTHUONGHIEU");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteTH(string id)
        {
            var customer = db.THUONGHIEUXEs.Single(x => x.MATHUONGHIEU == id);
            return View(customer);
        }

        // POST: admin/Khachhang/Delete/5
        [HttpPost]
        public ActionResult DeleteTH(string id, THUONGHIEUXE kh)
        {
            try
            {
                // TODO: Add delete logic here
                var data = db.THUONGHIEUXEs.Single(x => x.MATHUONGHIEU == id);
                db.THUONGHIEUXEs.DeleteOnSubmit(data);
                db.SubmitChanges();
                return RedirectToAction("IndexTHUONGHIEU");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateNCC()
        {
            return View();
        }

        // POST: admin/Khachhang/Create
        [HttpPost]
        public ActionResult CreateNCC(NHACUNGCAP collection)
        {
            try
            {
                db.NHACUNGCAPs.InsertOnSubmit(collection);
                db.SubmitChanges();
                return RedirectToAction("IndexCungCap");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteNCC(string id)
        {
            var customer = db.NHACUNGCAPs.Single(x => x.MANCC == id);
            return View(customer);
        }

        // POST: admin/Khachhang/Delete/5
        [HttpPost]
        public ActionResult DeleteNCC(string id, NHACUNGCAP kh)
        {
            try
            {
                // TODO: Add delete logic here
                var data = db.NHACUNGCAPs.Single(x => x.MANCC == id);
                db.NHACUNGCAPs.DeleteOnSubmit(data);
                db.SubmitChanges();
                return RedirectToAction("IndexCungCap");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditKH(string id)
        {

            var customer = db.KHACHHANGs.Single(x => x.MAKHACHHANG == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditKH(string id, KHACHHANG kh)
        {
            try
            {
                // TODO: Add update logic here
                KHACHHANG nd = db.KHACHHANGs.Single(x => x.MAKHACHHANG == id);
                nd.TENKHACHHANG = kh.TENKHACHHANG;
                nd.NGAYSINH = kh.NGAYSINH;
                nd.GIOITINH = kh.GIOITINH;
                nd.SODIENTHOAI = kh.SODIENTHOAI;
                nd.TAIKHOAN = kh.TAIKHOAN;
                nd.MATKHAU = kh.MATKHAU;
                nd.EMAIL = kh.EMAIL;
                nd.DIACHI = kh.DIACHI;
                db.SubmitChanges();
                return RedirectToAction("IndexKhachHang");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteKH(string id)
        {
            var customer = db.KHACHHANGs.Single(x => x.MAKHACHHANG == id);
            return View(customer);
        }

        // POST: admin/Khachhang/Delete/5
        [HttpPost]
        public ActionResult DeleteKH(string id, KHACHHANG kh)
        {
            try
            {
                // TODO: Add delete logic here
                var data = db.KHACHHANGs.Single(x => x.MAKHACHHANG == id);
                db.KHACHHANGs.DeleteOnSubmit(data);
                db.SubmitChanges();
                return RedirectToAction("IndexKhachHang");
            }
            catch
            {
                return View();
            }
        }
    }
}