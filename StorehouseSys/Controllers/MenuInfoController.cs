using Microsoft.AspNetCore.Mvc;

namespace StorehouseSys.Controllers
{
    public class MenuInfoController : Controller
    {
        public IActionResult MenuInfoView()
        {
            return View();
        }
    }
}
