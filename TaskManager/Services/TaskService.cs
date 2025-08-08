using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly string _filePath;
        private List<TaskItem> _tasks;

        public TaskService(string filePath)
        {
            _filePath = filePath;
            LoadTasks();
        }

        private void LoadTasks()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            else
            {
                _tasks = new List<TaskItem>();
            }
        }

        private void SaveTasks()
        {
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<TaskItem> GetAllTasks() => _tasks;

        public TaskItem GetTaskById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public void AddTask(TaskItem task)
        {
            int nextId = _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1;
            task.Id = nextId;
            _tasks.Add(task);
            SaveTasks();
        }

        public void UpdateTask(TaskItem task)
        {
            var index = _tasks.FindIndex(t => t.Id == task.Id);
            if (index != -1)
            {
                _tasks[index] = task;
                SaveTasks();
            }
        }

        public bool RemoveTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _tasks.Remove(task);
                SaveTasks();
                return true;
            }
            return false;
        }
    }
}