using Microsoft.AspNetCore.Mvc;
using NET104_ASM.Models;

namespace NET104_ASM.Controllers
{
    public class DkDnController : Controller
    {
        Net104Ps33862Context db = new Net104Ps33862Context();
        [HttpGet]
        public IActionResult Login()
        {
           
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            // Trả về một trang khác hoặc thực hiện hành động khác nếu người dùng đã đăng nhập
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        [HttpPost]
        public IActionResult Login(NguoiDung user) 
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                var u = db.NguoiDungs.FirstOrDefault(x => x.Email.Equals(user.Email) && x.MatKhau.Equals(user.MatKhau));
                if(u != null)
                {
                    HttpContext.Session.SetString("HoTen", u.HoTen.ToString());
                    HttpContext.Session.SetString("Sdt", u.Sdt.ToString());
                    HttpContext.Session.SetString("DiaChi", u.DiaChi.ToString());
                    HttpContext.Session.SetString("Email", u.Email.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại !";
                }    
            }
            return View();
        }
        
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(NguoiDung user)
        {
            db.NguoiDungs.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
           
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
    }
}

