using System.Collections.Generic;
using System.Linq;
using Todo.Api.Model;
using Todo.Api.Repository.Interface;

namespace Todo.Api.Repository.Concrete
{
    public class LoginRepository : ILoginRepository
    {
        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, user = "test", password = "pwd123", status = true });//, rememberMe = false
            users.Add(new User { Id = 2, user = "Giovanni", password = "pwd456", status = true });//, rememberMe = true

            return users.ToList();
        }
    }
}
