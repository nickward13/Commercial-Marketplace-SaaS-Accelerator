﻿namespace Microsoft.Marketplace.Saas.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Account Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AccountController : Controller
    {
        /// <summary>
        /// The SignIn..
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string" />.</param>
        /// <returns>
        /// The <see cref="IActionResult" />.
        /// </returns>
        public IActionResult SignIn(string returnUrl)
        {
            return this.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// The SignOut.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult" />.
        /// </returns>
        public override SignOutResult SignOut()
        {
            return this.SignOut(
                new AuthenticationProperties
                {
                    RedirectUri = "Home/Index/",
                },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// The SignIn.
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string" />.</param>
        /// <returns>
        /// The <see cref="IActionResult" />.
        /// </returns>
        public IActionResult AccessDenied(string returnUrl)
        {
            return this.View("Error");
        }

        /// <summary>
        /// The SignedOut.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult" />.
        /// </returns>
        public IActionResult SignedOut() => this.View();
    }
}