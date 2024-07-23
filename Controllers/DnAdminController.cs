using Microsoft.AspNetCore.Mvc;
using NET104_ASM.Models;

namespace NET104_ASM.Controllers
{
    public class DnAdminController : Controller
    {
        Net104Ps33862Context db = new Net104Ps33862Context();
        [HttpGet]
        public IActionResult LoginAdmin()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            // Trả về một trang khác hoặc thực hiện hành động khác nếu người dùng đã đăng nhập
            else
            {
                return RedirectToAction("Index", "admin");
            }
        }
        [HttpPost]
        public IActionResult LoginAdmin(Admin user)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                var u = db.Admins.FirstOrDefault(x => x.Email.Equals(user.Email) && x.MatKhau.Equals(user.MatKhau));
                if (u != null)
                {
                    HttpContext.Session.SetString("Email", u.Email.ToString());
                    return RedirectToAction("Index", "admin");
                }
                else
                {
                    ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại !";
                }
            }
            return View();
        }
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
    }
}
