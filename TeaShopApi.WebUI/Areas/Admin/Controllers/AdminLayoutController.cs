using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult _HeaderPartial()
        {
            return PartialView();
        }
		public PartialViewResult _SidebarPartial()
		{
			return PartialView();
		}
		public PartialViewResult _NavbarPartial()
		{
			return PartialView();
		}
		public PartialViewResult _ContentPartial()
		{
			return PartialView();
		}
        public PartialViewResult _PageTitlePartial()
        {
            return PartialView();
        }
    }
}
