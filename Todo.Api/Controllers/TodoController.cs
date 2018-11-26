using Microsoft.AspNetCore.Mvc;
using Todo.Api.Service.Interface;

namespace Todo.Api.Controllers
{
    public class TodoController : Controller
    {
        private ITaskService _taskService;

        public TodoController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }

            return View();
        }

        [HttpPost]
        public bool AddNewTask(string description)
        {
            return _taskService.AddNewTask(User.Identity.Name, description);
        }

        [HttpPut]
        public bool EditTask(int idTask, string newDescription)
        {
            return _taskService.EditTask(User.Identity.Name, idTask, newDescription);
        }

        [HttpDelete]
        public bool DeleteTask(int idTask)
        {
            return _taskService.DeleteTask(User.Identity.Name, idTask);
        }

        [HttpGet]
        public JsonResult GetListTaskItem()
        {
           return Json(_taskService.GetListTaskItem(User.Identity.Name));
        }

        [HttpPut]
        public bool MarkAsDone(int idTask, bool done)
        {
            return _taskService.MarkAsDone(idTask, User.Identity.Name, done);
        }


   }
}