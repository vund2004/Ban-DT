using Microsoft.AspNetCore.Mvc;
using NET104_ASM.Models;
using NET104_ASM.Models.Authentication;
using NET104_ASM.Models.Helper;
namespace NET104_ASM.Controllers
{
    public class GioHangController : Controller
    {

        Net104Ps33862Context db = new Net104Ps33862Context();
        public List<CartItem> Carts 
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if(data== null)
                {
                    data = new List<CartItem>();
                }    
                return data;
            } 
        }
 
        public IActionResult Index()
        {
            return View(Carts);
        }
        [BlockCartcs]
        public IActionResult AddToCart(int id,int SoLuong)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p=>p.MaSp== id);
            if(item== null)
            {
                var sanPham =db.SanPhams.SingleOrDefault(p=>p.MaSp== id);   
                item = new CartItem
                {
                   MaSp=id,
                   TenSp=sanPham.TenSp,
                   DonGiaSp=sanPham.GiaSp.Value,
                   SoLuongSp=SoLuong,
                   HinhSp=sanPham.HinhSp
                };
                myCart.Add(item);
            }
            else
            {
                item.SoLuongSp += SoLuong;
            }
            HttpContext.Session.Set("GioHang",myCart);
            return RedirectToAction("Index","GioHang");
        }
        public IActionResult Remove(int id)
{
    var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
    if (data != null)
    {
        var itemToRemove = data.FirstOrDefault(p => p.MaSp == id);
        if (itemToRemove != null)
        {
            data.Remove(itemToRemove);
            HttpContext.Session.Set("GioHang", data);
        }
    }

    return RedirectToAction("Index", "GioHang");
}



    }
}
