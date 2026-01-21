using Xunit;
using Moq;
using TaskManager_API.Controllers;
using TaskManager_API.Services;
using TaskManager_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = TaskManager_API.Models.Task;

namespace TaskManager_API.Tests
{
    public class TaskControllerTests
    {
        [Fact]
        public async System.Threading.Tasks.Task Get_Returns_All_Tasks()
        {
            // Arrange
            var mockService = new Mock<ITaskManagerService>();
            mockService.Setup(service => service.GetAsync())
                .ReturnsAsync(new List<Task> { 
                    new Task { Id = "1", TaskName = "Task 1" },
                    new Task { Id = "2", TaskName = "Task 2" }
                });
            var controller = new TaskController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var tasks = Assert.IsType<List<Task>>(result);
            Assert.Equal(2, tasks.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task Get_Returns_Task_By_Id()
        {
            // Arrange
            var mockService = new Mock<ITaskManagerService>();
            var taskId = "1";
            mockService.Setup(service => service.GetAsync(taskId))
                .ReturnsAsync(new Task { Id = taskId, TaskName = "Task 1" });
            var controller = new TaskController(mockService.Object);

            // Act
            var result = await controller.Get(taskId);

            // Assert
            var task = Assert.IsType<Task>(result);
            Assert.Equal(taskId, task.Id);
        }

        [Fact]
        public async System.Threading.Tasks.Task Post_Creates_New_Task()
        {
            // Arrange
            var mockService = new Mock<ITaskManagerService>();
            var newTask = new Task { Id = "1", TaskName = "New Task" };
            var controller = new TaskController(mockService.Object);

            // Act
            var result = await controller.Post(newTask);

            // Assert
            var createdAtActionResult = Assert.IsType<Microsoft.AspNetCore.Mvc.CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Task>(createdAtActionResult.Value);
            Assert.Equal(newTask.Id, returnValue.Id);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_Updates_Existing_Task()
        {
            // Arrange
            var mockService = new Mock<ITaskManagerService>();
            var taskId = "1";
            var existingTask = new Task { Id = taskId, TaskName = "Existing Task" };
            var updatedTask = new Task { Id = taskId, TaskName = "Updated Task" };  
            mockService.Setup(service => service.GetAsync(taskId))
                .ReturnsAsync(existingTask);
            var controller = new TaskController(mockService.Object);
            // Act
            var result = await controller.Update(taskId, updatedTask);
            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NoContentResult>(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Delete_Deletes_Existing_Task()
        {
            // Arrange
            var mockService = new Mock<ITaskManagerService>();
            var taskId = "1";
            var existingTask = new Task { Id = taskId, TaskName = "Existing Task" };
            mockService.Setup(service => service.GetAsync(taskId))
                .ReturnsAsync(existingTask);
            var controller = new TaskController(mockService.Object);
            // Act
            var result = await controller.Delete(taskId);
            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NoContentResult>(result);
        }
    }
}
