using Microsoft.AspNetCore.Mvc;

namespace StorehouseSys.Controllers
{
    public class ConsumableInfoController : Controller
    {
        public IActionResult ConsumableInfoView()
        {
            return View();
        }
    }
}
