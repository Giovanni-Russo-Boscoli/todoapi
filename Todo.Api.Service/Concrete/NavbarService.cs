using System;
using System.Collections.Generic;
using System.Text;
using Todo.Api.Model;
using Todo.Api.Repository.Interface;
using Todo.Api.Service.Interface;

namespace Todo.Api.Service.Concrete
{
    public class NavbarService : INavbarService
    {
        private INavbarRepository _navbarRepository;

        public NavbarService(INavbarRepository navbarRepository)
        {
            _navbarRepository = navbarRepository;
        }

        public IEnumerable<Navbar> GetNavbarItems()
        {
            return _navbarRepository.GetNavbarItems();
        }
    }
}
