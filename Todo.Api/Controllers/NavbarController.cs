using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Service.Interface;

namespace Todo.Api.Controllers
{
    public class NavbarController : Controller
    {

        private INavbarService _navbarService;

        public NavbarController(INavbarService navbarService)
        {
            _navbarService = navbarService;
        }

        // GET: Navbar
        [Authorize]
        public ActionResult Navbar()
        {
            var items = _navbarService.GetNavbarItems().ToList();
            return PartialView("_Navbar", items);
        }
    }
}