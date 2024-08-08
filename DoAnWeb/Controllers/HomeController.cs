using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb.Models;
namespace DoAnWeb.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult XeMay()
        {
            List<XEMAY> listProDuct = db.XEMAYs.ToList();
            return View(listProDuct);

        }
        public ActionResult XeMay8xemay()
        {
            var list = db.XEMAYs.Take(8).ToList();
            return View(list);
        }
        public ActionResult LoaiXe()
        {
            List<LOAIXE> dsLoaiXe = db.LOAIXEs.Take(8).ToList();
            return PartialView(dsLoaiXe);
                    
        }
        public ActionResult ThuongHieuXe()
        {
            List<THUONGHIEUXE> dsThuongHieu=db.THUONGHIEUXEs.Take(8).ToList();
            return PartialView(dsThuongHieu);
        }
        public ActionResult timXeMay(string txt_Search)
        {
            var list = db.XEMAYs.Where(s => s.TENXEMAY.Contains(txt_Search)).ToList();
            int sl = list.Count;
            ViewBag.SL = sl;
            return View(list);
        }
        public ActionResult XeMayTheoLoai(string MaLoai)
        {
            var listXe = db.XEMAYs.Where(t => t.MALOAIXE == MaLoai).ToList();
            if (listXe.Count == 0)
            {
                ViewBag.TB = "Không tìm thấy loại xe cần tìm";
            }
            return View(listXe);
        }
        public ActionResult XeMayTheoHang(string MaHang)
        {
            var listHang = db.XEMAYs.Where(s => s.MATHUONGHIEU == MaHang).ToList();
            if (listHang.Count == 0)
            {
                ViewBag.TB = "Không tìm thấy hãng xe cần tìm.";
            }
            return View(listHang);
        }
        public ActionResult XemThongTinXe(string MaXe)
        {
            XEMAY listxemmay = db.XEMAYs.Single(s => s.MAXEMAY == MaXe);
            if (listxemmay == null)
            {
                return HttpNotFound();
            }

            return View(listxemmay);
        }
        [HttpGet]
        public ActionResult DangKyTK()
        {
            return View();

        }
        [HttpPost]
        public ActionResult DangKyTK(KHACHHANG formCollection)
        {
            try
            {
                db.KHACHHANGs.InsertOnSubmit(formCollection);
                db.SubmitChanges();
                return RedirectToAction("DangNhapTK");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DangNhapTK()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapTK(FormCollection f)
        {
            var tendn = f["TenDN"];
            var matkhau = f["MatKhau"];
            if (tendn == "admin" && matkhau == "123456")
            {
                Session.Add("user", "pass");
                return RedirectToAction("IndexAdmin", "Admin");
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(c => c.TAIKHOAN == tendn && c.MATKHAU == matkhau);
                if (kh != null)
                {
                    ViewBag.TB = "Đăng nhập thành công";
                    Session["taikhoan"] = kh;
                    return RedirectToAction("Main");
                }
                else
                {
                    ViewBag.TB = "Sai tên đăng nhập hoặc sai mật khấu. Vui lòng nhập lại !";
                }
                return View();
            }
        }
    }
}