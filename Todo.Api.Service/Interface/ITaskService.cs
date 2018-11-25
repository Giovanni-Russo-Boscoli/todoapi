using System.Collections.Generic;
using Todo.Api.Service.DTO;

namespace Todo.Api.Service.Interface
{
    public interface ITaskService
    {
        IList<TodoTaskDTO> GetListTaskItem(string idUser);
        bool AddNewTask(string idUser, string description);
        bool EditTask(string idUser, int idTask, string newDescription);
        bool DeleteTask(string idUser, int idTask);
        bool MarkAsDone(int idTask, string idUser, bool done);
    }
}
