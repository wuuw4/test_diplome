using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomeConsApp
{
    public class TaskManager
    {
        private List<Task> tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(int taskId)
        {
            var taskToRemove = tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
            }
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            var taskToComplete = tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToComplete != null)
            {
                taskToComplete.IsCompleted = true;
            }
        }

        public List<Task> GetAllTasks()
        {
            return tasks;
        }
    }
}
