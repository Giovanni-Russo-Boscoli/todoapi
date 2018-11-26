using System.Collections.Generic;
using Todo.Api.Model;

namespace Todo.Api.Service.Interface
{
    public interface INavbarService
    {
        IEnumerable<Navbar> GetNavbarItems();
    }
}
