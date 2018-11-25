using System;
using System.Collections.Generic;
using System.Text;
using Todo.Api.Model;

namespace Todo.Api.Service.Interface
{
    public interface INavbarService
    {
        IEnumerable<Navbar> GetNavbarItems();
    }
}
