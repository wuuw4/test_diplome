
using DiplomeConsApp;
using Task = DiplomeConsApp.Task;

class Program
{
    static TaskManager taskManager = new TaskManager();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите опцию:");
            Console.WriteLine("1. Добавьте новую задачу");
            Console.WriteLine("2. Показать все задачи");
            Console.WriteLine("3. Пометить задачу выполненной");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("5. Выход");

            string input = Console.ReadLine();
            int option;
            if (int.TryParse(input, out option))
            {
                switch (option)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        ViewTasks();
                        break;
                    case 3:
                        MarkTaskAsCompleted();
                        break;
                    case 4:
                        RemoveTask();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Некорректная задача. Выберите снова.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректная задача. Выберите снова.");
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("Введите описание задачи:");
        string title = Console.ReadLine();
        Task newTask = new Task
        {
            Id = taskManager.GetAllTasks().Count + 1,
            Title = title,
            IsCompleted = false
        };
        taskManager.AddTask(newTask);
        Console.WriteLine("Задача была добавленна.");
    }

    static void ViewTasks()
    {
        var tasks = taskManager.GetAllTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Задача была не найдена.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Title} - {(task.IsCompleted ? "Выполнено" : "В ожидании")}");
            }
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.WriteLine("Введите ID задачи:");
        string inputId = Console.ReadLine();
        int taskId;
        if (int.TryParse(inputId, out taskId))
        {
            taskManager.MarkTaskAsCompleted(taskId);
            Console.WriteLine($"Задача {taskId} отмечена как выполненная.");
        }
        else
        {
            Console.WriteLine("Неправильно выбран ID.");
        }
    }

    static void RemoveTask()
    {
        Console.WriteLine("Выберите задачу, которую хотите удалить:");
        string inputId = Console.ReadLine();
        int taskId;
        if (int.TryParse(inputId, out taskId))
        {
            taskManager.RemoveTask(taskId);
            Console.WriteLine($"Задача {taskId} была удалена.");
        }
        else
        {
            Console.WriteLine("Неправильно выбран ID.");
        }
    }
}