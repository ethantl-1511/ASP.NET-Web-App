using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TheatreCMS3.Models;

namespace TheatreCMS3.Controllers
{
    // HeadAuthorLogin method Blog-section testing purposes
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> HeadAuthorLogin(LoginViewModel model, string returnUrl)
    {
        // Set variables to HeadAuthor credentials, only for testing purposes!!
        var headAuth = "HeadAuthor";
        var password = "password";

        var result = await SignInManager.PasswordSignInAsync(headAuth, password, model.RememberMe, shouldLockout: false);
        switch (result)
        {
            case SignInStatus.Success:
                return RedirectToLocal(returnUrl);
            case SignInStatus.Failure:
            default:
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
        }
    }
}