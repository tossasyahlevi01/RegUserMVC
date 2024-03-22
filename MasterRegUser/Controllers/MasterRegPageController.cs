using Microsoft.AspNetCore.Mvc;

namespace MasterRegUser.Controllers
{
    public partial class MasterRegController
    {
        public ActionResult LoginPage()
        {
            ViewData["Title"] = "LoginPage";
            ViewData["Controller"] = "MasterRegController";
            return View("~/Views/LoginPage/LoginPage.cshtml");
            //return View("~/Views/EMM/MMRequest.cshtml");
        }
        public ActionResult RegisterPage()
        {
            ViewData["Title"] = "RegisterPage";
            ViewData["Controller"] = "MasterRegController";
            return View("~/Views/RegisterPage/RegisterPage.cshtml");
            //return View("~/Views/EMM/MMRequest.cshtml");
        }
        public ActionResult RegisterAccount()
        {
            ViewData["Title"] = "RegisterAccount";
            ViewData["Controller"] = "MasterRegController";
            return View("~/Views/RegisterPage/RegisterAccount.cshtml");
            //return View("~/Views/EMM/MMRequest.cshtml");
        }
        public ActionResult DetailPage()
        {
            ViewData["Title"] = "DetailPage";
            ViewData["Controller"] = "MasterRegController";
            return View("~/Views/DetailPage/DetailPage.cshtml");
            //return View("~/Views/EMM/MMRequest.cshtml");
        }
    }
}
