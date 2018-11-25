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
                NameOption = "Prontuario",
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
                NameOption = "PsicoSocial",
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
                NameOption = "PsicoSocial 2",
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
                NameOption = "PsicoSocial 3",
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
                NameOption = "PsicoSocial 2",
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
                NameOption = "PsicoSocial 2",
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
                NameOption = "PsicoSocial 2",
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
                NameOption = "PsicoSocial 2",
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
                NameOption = "Menu1",
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
                NameOption = "Menu2",
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
                NameOption = "Action",
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
                NameOption = "Another action",
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
                NameOption = "Something else here",
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
                NameOption = "Dropdown",
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
                NameOption = "Action - 2",
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
                NameOption = "Another action - 2",
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
                NameOption = "Something else here -2",
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
                NameOption = "Dropdown -2",
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
                NameOption = "Action - 3",
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
                Tooltip = "Relatórios"
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
                Tooltip = "Configurações"
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
                Tooltip = "Usuário"
            });
            menu.Add(new Navbar
            {
                Id = 4000,
                NameOption = "Perfil",
                Controller = "Home",
                Action = "Index",
                ImageClass = "glyphicon glyphicon-user",
                Status = true,
                IsParent = false,
                ParentId = 3000,
                RighSide = true,
                Tooltip = ""
            });
            menu.Add(new Navbar
            {
                Id = 5000,
                NameOption = "Configurações",
                Controller = "Home",
                Action = "Index",
                ImageClass = "fa fa-cog",
                Status = false,
                IsParent = false,
                ParentId = 3000,
                RighSide = true,
                Tooltip = ""
            });
            menu.Add(new Navbar
            {
                Id = 6000,
                NameOption = "Mensagens",
                Controller = "Home",
                Action = "Index",
                ImageClass = "fa fa-envelope",
                Status = false,
                IsParent = false,
                ParentId = 3000,
                RighSide = true,
                Tooltip = ""
            });
            //menu.Add(new Navbar
            //{
            //    Id = 7000,
            //    nameOption = "Sair",
            //    controller = "Account",
            //    action = "LogOff",
            //    imageClass = "fa fa-power-off",
            //    estatus = true,
            //    isParent = false,
            //    parentId = 3000,
            //    righSide = true,
            //    tooltip = ""
            //});

            return menu;
        }
    }
}
