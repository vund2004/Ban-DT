using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET104_ASM.Models;

namespace NET104_ASM.Controllers
{
    public class PhoneController : Controller
    {
       

        private readonly Net104Ps33862Context _context;

        public PhoneController(Net104Ps33862Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int danhmuc)
        {
            ViewBag.DanhMuc = _context.LoaiSanPhams.ToList();
            if (danhmuc == 1007)
            {
                return View(_context.SanPhams.ToList());
            }
            if (danhmuc != default(int))
            {
                // Truy vấn các sản phẩm thuộc về danh mục sản phẩm có tên tương ứng
                var listProduct = _context.SanPhams
                    .Where(x => x.MaLoaiSpNavigation.MaLoaiSp == danhmuc)
                    .ToList();

                return View(listProduct);
            }
            
            return View(_context.SanPhams.ToList());
        }

        public async Task<IActionResult> CTsanPham(int? id)
        {
            var productDetail = _context.SanPhams.FirstOrDefault(p => p.MaSp == id);
            return View(productDetail);
        }

        public async Task<IActionResult> Search(int danhmuc, string query)
        {
            ViewBag.DanhMuc = await _context.LoaiSanPhams.ToListAsync();

            var sanphams = _context.SanPhams.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                sanphams = sanphams.Where(p => p.TenSp.Contains(query));
            }

            if (danhmuc != default(int))
            {
                sanphams = sanphams.Where(p => p.MaLoaiSpNavigation.MaLoaiSp == danhmuc);
            }

            var result = await sanphams.ToListAsync();

            return View(result);
        }

    }
}
