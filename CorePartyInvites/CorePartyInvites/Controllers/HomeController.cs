using Microsoft.AspNetCore.Mvc;

namespace CorePartyInvites.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
