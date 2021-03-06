﻿using System.Collections.Generic;
using Todo.Api.Model;

namespace Todo.Api.Repository.Interface
{
    public interface ILoginRepository
    {
        IEnumerable<User> GetUsers();
    }
}
