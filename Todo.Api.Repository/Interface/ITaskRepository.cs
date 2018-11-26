using System.Collections.Generic;
using Todo.Api.Model;

namespace Todo.Api.Repository.Interface
{
    public interface ITaskRepository
    {
        IList<TodoTask> GetListTaskItem(string idUser);
        bool AddNewTask(string idUser, string description);
        bool EditTask(string idUser, int idTask, string newDescription);
        bool DeleteTask(string idUser, int idTask);
        bool MarkAsDone(int idTask, string idUser, bool done);
    }
}
