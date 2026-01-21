using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace TaskManager_API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [EnableCors("Allow")]
    public class TaskController : ControllerBase
    {
        private readonly Services.ITaskManagerService _taskManagerService;
        public TaskController(Services.ITaskManagerService taskManagerService)
        {
            _taskManagerService = taskManagerService;
        }

        [HttpGet]
        public async Task<List<Models.Task>> Get() =>
            await _taskManagerService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<Models.Task> Get(string id)
        {
            var task = await _taskManagerService.GetAsync(id);
            if (task is null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return task;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Models.Task newTask)
        {
            await _taskManagerService.CreateAsync(newTask);
            return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Models.Task updatedTask)
        {
            var task = await _taskManagerService.GetAsync(id);
            if (task is null)
            {
                return NotFound();
            }
            updatedTask.Id = task.Id;
            await _taskManagerService.UpdateAsync(id, updatedTask);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var task = await _taskManagerService.GetAsync(id);
            if (task is null)
            {
                return NotFound();
            }
            await _taskManagerService.RemoveAsync(id);
            return NoContent();
        }
    }
}
