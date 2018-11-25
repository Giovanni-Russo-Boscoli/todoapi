using System;
using System.Collections.Generic;
using System.Text;
using Todo.Api.Model;

namespace Todo.Api.Repository.Interface
{
    public interface ILoginRepository
    {
        IEnumerable<User> GetUsers();
    }
}
