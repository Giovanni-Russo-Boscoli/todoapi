using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;

namespace Todo.Api.Controllers
{
    public class TodoController : Controller
    {

        private const string formatDate = "dd/MM/yyyy H:mm";
        private StringBuilder strDescription = new StringBuilder(
            @"
            What is Lorem Ipsum?
            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

            Why do we use it?
            It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).

            ");
        
        public IActionResult Index()
        {
            //IEnumerable<TodoViewModel> listModels = Enumerable.Empty<TodoViewModel>();
            IList<TodoViewModel> listModels = new List<TodoViewModel>();
            listModels.Add(
                new TodoViewModel()
                {
                    CreationDate = DateTime.Now.ToString(formatDate),
                    Description = strDescription.ToString(),
                    ModificationDate = DateTime.Now.ToString(formatDate)
                });
            listModels.Add(
                new TodoViewModel()
                {
                    CreationDate = DateTime.Now.ToString(formatDate),
                    Description = "TESTE DE DESCRICAO",
                    ModificationDate = DateTime.Now.ToString(formatDate)
                }
                 );
            //ModelState.AddModelError("Error", "Error Ocurred");
            return View(listModels);
        }

        public void AddNewTask()
        {
            //HtmlHelper.ClientValidationEnabled = false;
            string a = "";
        }
    }
}