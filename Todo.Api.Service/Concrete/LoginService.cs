using System;
using System.Collections.Generic;
using System.Text;
using Todo.Api.Model;
using Todo.Api.Repository.Interface;
using Todo.Api.Service.Interface;

namespace Todo.Api.Service.Concrete
{
    public class LoginService :ILoginService
    {
        private ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _loginRepository.GetUsers();
        }
    }
}
