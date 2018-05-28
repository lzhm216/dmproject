using Microsoft.AspNetCore.Antiforgery;
using SPA.DocumentManager.Controllers;

namespace SPA.DocumentManager.Web.Host.Controllers
{
    public class AntiForgeryController : DocumentManagerControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
