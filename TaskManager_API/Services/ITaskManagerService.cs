using TaskManager_API.Models;

namespace TaskManager_API.Services
{
    public interface ITaskManagerService
    {
        Task<List<Models.Task>> GetAsync();
        Task<Models.Task?> GetAsync(string id);
        System.Threading.Tasks.Task CreateAsync(Models.Task newTask);
        System.Threading.Tasks.Task UpdateAsync(string id, Models.Task updatedTask);
        System.Threading.Tasks.Task RemoveAsync(string id);
    }
}
