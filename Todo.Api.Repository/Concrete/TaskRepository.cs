using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Todo.Api.Model;
using Todo.Api.Repository.Interface;

namespace Todo.Api.Repository.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        private const string pathPrefix = @"..\Todo.Api.Repository\JsonFile\";
        private const string pathSufix = ".json";
        private const string formatStringDateTime = "dd/MM/yyyy HH:mm";

        public IList<TodoTask> GetListTaskItem(string idUser)
        {
            return ReadJsonFile(idUser);
        }

        public bool AddNewTask(string idUser, string description)
        {
            IList<TodoTask> listTodoTask = ReadJsonFile(idUser);
            int maxId = 0;

            if (listTodoTask == null)
            {
                listTodoTask = new List<TodoTask>();
            }
            else
            {
                if (listTodoTask.Count > 0)
                {
                    maxId = listTodoTask.Max(x => x.Id);
                }
            }

            listTodoTask.Add(new TodoTask()
            {
                CreationDate = DateTime.Now.ToString(formatStringDateTime),
                Description = description,
                Id = (++maxId),
                ModificationDate = DateTime.Now.ToString(formatStringDateTime),
                Status = false
            });
                       
            UpdateJsonFile(listTodoTask, idUser);
            return true;
        }

        public bool EditTask(string idUser, int idTask, string newDescription)
        {
            IList<TodoTask> listTodoTask = ReadJsonFile(idUser);
            listTodoTask.Where(x => x.Id.Equals(idTask)).FirstOrDefault().Description = newDescription;
            listTodoTask.Where(x => x.Id.Equals(idTask)).FirstOrDefault().ModificationDate = DateTime.Now.ToString(formatStringDateTime);
            UpdateJsonFile(listTodoTask, idUser);
            return true;
        }

        public bool DeleteTask(string idUser, int idTask)
        {
            IList<TodoTask> listTodoTask = ReadJsonFile(idUser);
            listTodoTask.Remove(listTodoTask.Where(x=>x.Id.Equals(idTask)).FirstOrDefault());
            if (listTodoTask.Count > 0)
            {
                UpdateJsonFile(listTodoTask, idUser);
            }
            else
            {
                File.Delete(pathPrefix + idUser + pathSufix);
            }
            return true;
        }

        private IList<TodoTask> ReadJsonFile(string idUser)
        {
                if(!File.Exists(pathPrefix + idUser + pathSufix))
                {
                return null;
                }

                using (StreamReader r = new StreamReader(pathPrefix + idUser + pathSufix))//TodoTaskListJson
                {
                    return JsonConvert.DeserializeObject<IList<TodoTask>>(r.ReadToEnd());
                }
        }

        //TODO: fix return (boolean)
        private void UpdateJsonFile(IList<TodoTask> listTodoTask, string idUser)
        {
            string json = JsonConvert.SerializeObject(listTodoTask.ToArray());
            System.IO.File.WriteAllText(pathPrefix + idUser + pathSufix , json);
        }

        public bool MarkAsDone(int idTask, string idUser, bool done)
        {
            IList<TodoTask> listTodoTask = ReadJsonFile(idUser);
            listTodoTask.Where(x => x.Id.Equals(idTask)).FirstOrDefault().Status = done;
            UpdateJsonFile(listTodoTask, idUser);
            return true;
        }
    }
}
