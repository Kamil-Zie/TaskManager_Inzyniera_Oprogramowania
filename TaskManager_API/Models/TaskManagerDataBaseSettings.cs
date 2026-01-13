using System.Globalization;

namespace TaskManager_API.Models
{
    public class TaskManagerDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string BooksCollectionName { get; set; }
    }
}
