using Moq;
using System;
using System.Collections.Generic;
using Todo.Api.Model;
using Todo.Api.Repository.Interface;
using Todo.Api.Service.Concrete;
using Todo.Api.Service.DTO;
using Xunit;

namespace Todo.Api.Service.Tests
{
    public class TaskServiceTest
    {

        private const int _idTask = 1;
        private const string validUser = "Giovanni";
        private const string _description = "Description Test";
        private const string formatStringDateTime = "dd/MM/yyyy HH:mm";
        private const bool _done = true;
        Mock<ITaskRepository> _moqTaskRepository = new Mock<ITaskRepository>();
        TaskService taskService; 

        public TaskServiceTest()
        {
            List<TodoTask> listTodoTask = new List<TodoTask>() {
                 new TodoTask()
                 {
                     Id= 1,
                     CreationDate = DateTime.Now.ToString(formatStringDateTime),
                     Description = "First Description",
                     ModificationDate =  DateTime.Now.ToString(formatStringDateTime),
                     Status = false
                 },
                 new TodoTask()
                 {
                     Id= 2,
                     CreationDate = DateTime.Now.ToString(formatStringDateTime),
                     Description = "Second Description",
                     ModificationDate =  DateTime.Now.ToString(formatStringDateTime),
                     Status = false
                 },
                 new TodoTask()
                 {
                     Id= 3,
                     CreationDate = DateTime.Now.ToString(formatStringDateTime),
                     Description = "Third Description",
                     ModificationDate =  DateTime.Now.ToString(formatStringDateTime),
                     Status = false
                 },
                 new TodoTask()
                 {
                     Id= 4,
                     CreationDate = DateTime.Now.ToString(formatStringDateTime),
                     Description = "Fourth Description",
                     ModificationDate =  DateTime.Now.ToString(formatStringDateTime),
                     Status = false
                 }
            };
            _moqTaskRepository.Setup(x => x.GetListTaskItem(validUser)).Returns(listTodoTask);
            _moqTaskRepository.Setup(x => x.AddNewTask(validUser, _description)).Returns(true);
            _moqTaskRepository.Setup(x => x.EditTask(validUser, _idTask, _description)).Returns(true);
            _moqTaskRepository.Setup(x => x.DeleteTask(validUser, _idTask)).Returns(true);
            _moqTaskRepository.Setup(x => x.MarkAsDone(_idTask, validUser, _done)).Returns(true);
            taskService = new TaskService(_moqTaskRepository.Object);
        }

        [Fact]
        public void Should_ReturnListTaskItem_When_ValidUserProvided()
        {
            var result = taskService.GetListTaskItem(validUser);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void Should_ReturnEmptyListTaskItem_When_InvalidUserProvided()
        {
            var result = taskService.GetListTaskItem("Invalid User");
            Assert.Null(result);
        }

        [Theory]
        [InlineData("","Description 1")]
        [InlineData(null, "Description 2")]
        [InlineData(validUser, "")]
        [InlineData(validUser, null)]
        public void Should_ReturnFalse_When_AddingWithInvalidInputs(string idUser, string description)
        {
            var result = taskService.AddNewTask(idUser, description);
            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnFalse_When_ValidInputsProvided()
        {
            var result = taskService.AddNewTask(validUser, _description);
            Assert.True(result);
        }

        [Theory]
        [InlineData("", _idTask, _description)]
        [InlineData(null, _idTask, _description)]
        [InlineData(validUser, 0, _description)]
        [InlineData(validUser, _idTask, "")]
        [InlineData(validUser, _idTask, null)]
        public void Should_ReturnFalse_When_EditingWithInvalidInputs(string idUser, int idTask, string description)
        {
            var result = taskService.EditTask(idUser, idTask, description);
            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnFalse_When_EditingWithValidInputs()
        {
            var result = taskService.EditTask(validUser, _idTask, _description);
            Assert.True(result);
        }

        [Theory]
        [InlineData("", _idTask)]
        [InlineData(null, _idTask)]
        [InlineData(validUser, 0)]
        public void Should_ReturnFalse_When_DeletingWithInvalidInputs(string idUser, int idTask)
        {
            var result = taskService.DeleteTask(idUser, idTask);
            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnFalse_When_DelitingWithValidInputs()
        {
            var result = taskService.DeleteTask(validUser, _idTask);
            Assert.True(result);
        }

        [Theory]
        [InlineData(_idTask, "")]
        [InlineData(_idTask, null)]
        [InlineData(0, validUser)]
        public void Should_ReturnFalse_When_MarkingAsDoneWithInvalidInputs(int idTask, string idUser)
        {
            var result = taskService.MarkAsDone(idTask, idUser, _done);
            Assert.False(result);
        }

        [Fact]
        public void Should_ReturnFalse_When_MarkingAsDoneWithValidInputs()
        {
            var result = taskService.MarkAsDone(_idTask, validUser, _done);
            Assert.True(result);
        }
    }
}
