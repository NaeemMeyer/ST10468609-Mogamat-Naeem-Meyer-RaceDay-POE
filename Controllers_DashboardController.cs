using Microsoft.AspNetCore.Mvc;

namespace RaceDayMVC.Controllers;

public class DashboardController : Controller
{
    public IActionResult Dashboard()
    {
        var role =
            HttpContext.Session.GetString("Role");

        if(role != "Organiser")
        {
            return RedirectToAction(
                "Login",
                "Account");
        }

        return View();
    }
}
