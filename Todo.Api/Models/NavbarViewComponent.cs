using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Service.Interface;

namespace Todo.Api.Models
{
    public class NavbarViewComponent: ViewComponent
    {
        private INavbarService _navbarService;

        public NavbarViewComponent(INavbarService navbarService)
        {
            _navbarService = navbarService;
        }

        // GET: Navbar
        [Authorize]
        public IViewComponentResult Invoke()
        {
            var navabarViewModel = _navbarService.GetNavbarItems(); 
            return View(navabarViewModel);
        }
    }
}
