using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET104_ASM.Models;
using NET104_ASM.Models.Authentication;
using NET104_ASM.Areas.Admin.Controllers;
using System;

namespace NET104_ASM.Areas.Admin.Controllers
{
    
    [Authentication]

    [Area("Admin")]
    [Route("Admin")]


    public class HomeAdminController : Controller
    {
        Net104Ps33862Context db=new Net104Ps33862Context();

        public IActionResult Index()
        {
            return View();
        }
        [Route("SanPham")]
        public IActionResult DsSanPham()
        {
            var lstsanpham = db.SanPhams.ToList();
            return View(lstsanpham);
        }
        [Route("ThemSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaLoaiSp = new SelectList(db.LoaiSanPhams.ToList(), "MaLoaiSp", "TenLoaiSp");
            return View();
        }
        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DsSanPham");
            }
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int id)
        {
            ViewBag.MaLoaiSp = new SelectList(db.LoaiSanPhams.ToList(), "MaLoaiSp", "TenLoaiSp");
            var sanPham = db.SanPhams.Find(id);

            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("DsSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }



        [Route("DsLoaiSanPham")]

        public IActionResult DsLoaiSanPham()
        {
            var lstloaisanpham = db.LoaiSanPhams.ToList();
            return View(lstloaisanpham);
        }
        [Route("ThemLoaiSanPham")]
        [HttpGet]
        public IActionResult ThemLoaiSanPham()
        {
            return View();
        }
        [Route("ThemLoaiSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemLoaiSanPham(LoaiSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DsLoaiSanPham");
            }
            return View(sanPham);
        }

        [Route("SuaLoaiSanPham")]
        [HttpGet]
        public IActionResult SuaLoaiSanPham(int id)
        {
            
            var sanPham = db.LoaiSanPhams.Find(id);

            return View(sanPham);
        }
        [Route("SuaLoaiSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaLoaiSanPham(LoaiSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("DsLoaiSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("DsNguoiDung")]
        public IActionResult DsNguoiDung()
        {
            var lstsanpham = db.NguoiDungs.ToList();
            return View(lstsanpham);
        }
        [Route("ThemNguoiDung")]
        [HttpGet]
        public IActionResult ThemNguoiDung()
        {
            return View();
        }
        [Route("ThemNguoiDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNguoiDung(NguoiDung sanPham)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DsNguoiDung");
            }
            return View(sanPham);
        }
        [Route("SuaNguoiDung")]
        [HttpGet]
        public IActionResult SuaNguoiDung(int id)
        {

            var sanPham = db.NguoiDungs.Find(id);

            return View(sanPham);
        }
        [Route("SuaNguoiDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNguoiDung(NguoiDung sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("DsNguoiDung", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int id) 
        {
            TempData["Message"] = "";
            var hoaDonChiTiets = db.HoaDonChiTiets.Where(x=>x.MaSp==id).ToList();
            if(hoaDonChiTiets.Count()>0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DsSanPham", "HomeAdmin");
            }    
            var gioHangChiTiets=db.GioHangChiTiets.Where(x => x.MaSp == id);
            if (gioHangChiTiets.Any()) db.RemoveRange(gioHangChiTiets);
            db.Remove(db.SanPhams.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DsSanPham", "HomeAdmin");
        }
        [Route("XoaLoaiSanPham")]
        [HttpGet]
        public IActionResult XoaLoaiSanPham(int id)
        {
            TempData["Message"] = "";
        /*    var sanPhams = db.SanPhams.Where(x => x.id == id).ToList();
            if (sanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DsLoaiSanPham", "HomeAdmin");
            }*/
            var sanPhams = db.LoaiSanPhams.Where(x => x.MaLoaiSp == id);
            if (sanPhams.Any()) db.RemoveRange(sanPhams);
            db.Remove(db.LoaiSanPhams.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DsLoaiSanPham", "HomeAdmin");
        }
        [Route("XoaNguoiDung")]
        [HttpGet]
        public IActionResult XoaNguoiDung(int id)
        {
            TempData["Message"] = "";
            var hoaDons = db.HoaDons.Where(x => x.MaNguoiDung == id).ToList();
            if (hoaDons.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DsNguoiDung", "HomeAdmin");
            }
            var gioHangs = db.GioHangs.Where(x => x.MaNguoiDung == id);
            if (gioHangs.Any()) db.RemoveRange(gioHangs);
            db.Remove(db.NguoiDungs.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DsNguoiDung", "HomeAdmin");
        }
        [HttpGet]
        [Route("ChiTietLoaiSanPham")]
        public IActionResult ChiTietLoaiSanPham(int id)
        {
            // Tìm loại sản phẩm trong cơ sở dữ liệu
            var loaiSanPham = db.LoaiSanPhams
                .Include(lsp => lsp.SanPhams) // Kết nối với bảng sản phẩm
                .FirstOrDefault(lsp => lsp.MaLoaiSp == id);

            if (loaiSanPham == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy
            }

            return View(loaiSanPham); // Trả về view hiển thị chi tiết loại sản phẩm
        }
        [HttpGet]
        [Route("ChiTieSanPham")]
        public IActionResult ChiTietSanPham(int id)
        {
            // Tìm sản phẩm trong cơ sở dữ liệu
            var sanPham = db.SanPhams
                .Include(sp => sp.MaLoaiSpNavigation) // Kết nối với bảng LoaiSanPham
                .FirstOrDefault(sp => sp.MaSp == id);

            if (sanPham == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy sản phẩm
            }

            return View(sanPham); // Trả về view hiển thị chi tiết sản phẩm
        }

        [HttpGet]
        [Route("ChiTietNguoiDung")]
        public IActionResult ChiTietNguoiDung(int id)
        {
            // Tìm người dùng trong cơ sở dữ liệu
            var nguoiDung = db.NguoiDungs
                .FirstOrDefault(nd => nd.MaNguoiDung == id);

            if (nguoiDung == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy người dùng
            }

            return View(nguoiDung); // Trả về view hiển thị chi tiết người dùng
        }

    }


}
