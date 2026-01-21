using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskManager_API.Models;

namespace TaskManager_API.Services
{
    public class TaskManagerService : ITaskManagerService
    {
        private readonly IMongoCollection<Models.Task> _taskCollection;

        public TaskManagerService(IOptions<TaskManagerDataBaseSettings> taskManagerDatabaseSettings)
        {
            var mongoClinet = new MongoClient(taskManagerDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClinet.GetDatabase(taskManagerDatabaseSettings.Value.DatabaseName);
            _taskCollection = mongoDatabase.GetCollection<Models.Task>(taskManagerDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Models.Task>> GetAsync() =>
            await _taskCollection.Find(_ => true).ToListAsync();

        public async Task<Models.Task?> GetAsync(string id) =>
            await _taskCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async System.Threading.Tasks.Task CreateAsync(Models.Task newTask) =>
            await _taskCollection.InsertOneAsync(newTask);

        public async System.Threading.Tasks.Task UpdateAsync(string id, Models.Task updatedTask) =>
            await _taskCollection.ReplaceOneAsync(x => x.Id == id, updatedTask);

        public async System.Threading.Tasks.Task RemoveAsync(string id) =>
            await _taskCollection.DeleteOneAsync(x => x.Id == id);
    }
}
