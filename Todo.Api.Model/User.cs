using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Api.Model
{
    public class User
    {
        public int Id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public bool rememberMe { get; set; }
    }
}
