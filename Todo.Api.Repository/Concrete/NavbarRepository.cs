using System;
using System.Collections.Generic;
using System.Text;
using Todo.Api.Model;
using Todo.Api.Repository.Interface;

namespace Todo.Api.Repository.Concrete
{
    public class NavbarRepository : INavbarRepository
    {
        public IEnumerable<Navbar> GetNavbarItems()
        {
            var menu = new List<Navbar>();

            // left side
            menu.Add(new Navbar
            {
                Id = 100,
                NameOption = "TODO",
                Controller = "Todo",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-th-list",
                Status = true,
                IsParent = false,
                ParentId = 0,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 300,
                NameOption = "Menu 1",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = false,
                ParentId = 0
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 400,
                NameOption = "Menu 2",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = true,
                ParentId = 0
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 500,
                NameOption = "Menu 3",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = false,
                ParentId = 400
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 600,
                NameOption = "Menu 4",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = true,
                ParentId = 400
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 700,
                NameOption = "Menu 5",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = false,
                ParentId = 600
                ,
                RighSide = false
            });            
            menu.Add(new Navbar
            {
                Id = 800,
                NameOption = "Menu 6",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = false,
                ParentId = 600
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 900,
                NameOption = "Menu 7",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = false,
                ParentId = 600
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 1000,
                NameOption = "Menu 8",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = false,
                ParentId = 600
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 1,
                NameOption = "Menu 9",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = false,
                ParentId = 0
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 2,
                NameOption = "Menu 10",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-calendar",
                Status = false,
                IsParent = true,
                ParentId = 0
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 3,
                NameOption = "Menu 11",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = false,
                ParentId = 2
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 4,
                NameOption = "Menu 12",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = false,
                ParentId = 2
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 5,
                NameOption = "Menu 13",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = false,
                ParentId = 2
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 6,
                NameOption = "Menu 14",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = true,
                ParentId = 2
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 7,
                NameOption = "Menu 15",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = false,
                ParentId = 6
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 8,
                NameOption = "Menu 16",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = false,
                ParentId = 6
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 9,
                NameOption = "Menu 17",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = false,
                ParentId = 6
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 10,
                NameOption = "Menu 18",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = true,
                ParentId = 6
                ,
                RighSide = false
            });
            menu.Add(new Navbar
            {
                Id = 11,
                NameOption = "Menu 19",
                Controller = "Home",
                Action = "Dropdown",
                Status = false,
                IsParent = false,
                ParentId = 10
                ,
                RighSide = false
            });

            //right side
            menu.Add(new Navbar
            {
                Id = 1000,
                NameOption = "",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-tag",
                Status = false,
                IsParent = false,
                ParentId = 0,
                RighSide = true,
                Tooltip = "Reports"
            });
            menu.Add(new Navbar
            {
                Id = 2000,
                NameOption = "",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-wrench",
                Status = false,
                IsParent = false,
                ParentId = 0,
                RighSide = true,
                Tooltip = "Configuration"
            });
            menu.Add(new Navbar
            {
                Id = 3000,
                NameOption = "",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-user",
                Status = true,
                IsParent = true,
                ParentId = 0,
                RighSide = true,
                Tooltip = "User"
            });
            menu.Add(new Navbar
            {
                Id = 4000,
                NameOption = "Menu 20",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-user",
                Status = false,
                IsParent = false,
                ParentId = 3000,
                RighSide = true,
                Tooltip = ""
            });
            menu.Add(new Navbar
            {
                Id = 5000,
                NameOption = "Menu 21",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-certificate",
                Status = false,
                IsParent = false,
                ParentId = 3000,
                RighSide = true,
                Tooltip = ""
            });
            menu.Add(new Navbar
            {
                Id = 6000,
                NameOption = "Menu 22",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-envelope",
                Status = false,
                IsParent = false,
                ParentId = 3000,
                RighSide = true,
                Tooltip = ""
            });

            return menu;
        }
    }
}
