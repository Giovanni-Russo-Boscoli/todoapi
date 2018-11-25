using System;
using System.Collections.Generic;
using System.Text;
using Todo.Api.Model;
using Todo.Api.Repository.Interface;
using Todo.Api.Service.DTO;
using Todo.Api.Service.Interface;

namespace Todo.Api.Service.Concrete
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IList<TodoTaskDTO> GetListTaskItem(string idUser)
        {
            return ConvertListTodoTaskToListTodoTaskDTO(_taskRepository.GetListTaskItem(idUser));
        }

        private IList<TodoTaskDTO> ConvertListTodoTaskToListTodoTaskDTO(IList<TodoTask> listTodoTask)
        {
            if(listTodoTask == null)
            {
                return null;
            }

            IList<TodoTaskDTO> listTodoTaskDTO = new List<TodoTaskDTO>();

            foreach (var item in listTodoTask)
            {
                listTodoTaskDTO.Add(
                    new TodoTaskDTO()
                    {
                        CreationDate = item.CreationDate,
                        Description = item.Description,
                        ModificationDate = item.ModificationDate,
                        Status = item.Status,
                        Id = item.Id
                    });
            }
            return listTodoTaskDTO;
        }

        public bool AddNewTask(string idUser, string description)
        {
            if (string.IsNullOrEmpty(idUser) || string.IsNullOrEmpty(description)) {
                return false;
            }
            return _taskRepository.AddNewTask(idUser, description);
        }

        public bool EditTask(string idUser, int idTask, string newDescription)
        {
            //idTask != 0  in case to use DB
            if (string.IsNullOrEmpty(idUser) || string.IsNullOrEmpty(newDescription) || idTask == 0)
            {
                return false;
            }
            return _taskRepository.EditTask(idUser, idTask, newDescription);
        }

        public bool DeleteTask(string idUser, int idTask)
        {
            //idTask != 0  in case to use DB
            if (string.IsNullOrEmpty(idUser) || idTask == 0)
            {
                return false;
            }
            return _taskRepository.DeleteTask(idUser, idTask);
        }

        public bool MarkAsDone(int idTask, string idUser, bool done)
        {
            //idTask != 0  in case to use DB
            if (string.IsNullOrEmpty(idUser) || idTask == 0)
            {
                return false;
            }
            return _taskRepository.MarkAsDone(idTask, idUser, done);
        }
    }
}
