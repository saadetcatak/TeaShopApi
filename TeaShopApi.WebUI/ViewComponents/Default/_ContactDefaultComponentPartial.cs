using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.ViewComponents.Default
{
    public class _ContactDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
