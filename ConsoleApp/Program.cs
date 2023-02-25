using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
class Task
{
    public Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
class Program
{
    static void Main()
    {
        List<Task> tasks = new List<Task>();
        while (true)
        {
            Console.WriteLine("ToDo List");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Edit task");
            Console.WriteLine("3. Delete completed task");
            Console.WriteLine("4. View task list");
            Console.WriteLine("5. Mark Task Completed");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(tasks);
                    break;
                case "2":
                    EditTaks(tasks);
                    break;
                case "3":
                    DeletTask(tasks);
                    break;
                case "4":
                    ShowTask(tasks);
                    break;
                case "5":
                    CompleteTask(tasks);
                    break;
                case "6":
                    Console.WriteLine("Thank you for using ToDo List!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void AddTask(List<Task> tasks)
    {
        Console.Write("Enter the task title: ");
        string title = Console.ReadLine();

        Console.Write("Enter the task description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the task due date (dd/mm/aaaa): ");
        DateTime dueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Task task = new Task(title, description, dueDate);
        tasks.Add(task);

        Console.WriteLine("Task added successfully.");
    }

    static void EditTaks(List<Task> tasks)
    {
        Console.Write("Enter the number of the task you want to edit: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= tasks.Count)
        {
            Console.WriteLine("Invalid task number.");
            return;
        }

        Task task = tasks[index];

        Console.Write("Enter new task title (or leave blank to keep the same): ");
        string title = Console.ReadLine();

        Console.Write("Enter the new task description (or leave it blank to keep it the same): ");
        string description = Console.ReadLine();

        Console.Write("Enter the new task due date (or leave it blank to keep it the same - dd/MM/yyyy format): ");
        string dueDateStr = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(title))
        {
            task.Title = title;
        }

        if (!string.IsNullOrWhiteSpace(description))
        {
            task.Description = description;
        }

        if (!string.IsNullOrWhiteSpace(dueDateStr))
        {
            task.DueDate = DateTime.ParseExact(dueDateStr, "dd/MM/yyyy", null);
        }

        Console.WriteLine("Job updated successfully.");
    }

    static void DeletTask(List<Task> tasks)
    {
        tasks.RemoveAll(task => task.IsCompleted);

        Console.WriteLine("Completed tasks successfully removed.");
    }

    static void ShowTask(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("There are no tasks in the list.");
        }
        else
        {
            Console.WriteLine("Task List:");
            Console.WriteLine("{0,-3} {1,-30} {2,-20} {3,-10}", "ID", "Title", "Due date", "Completed");

            tasks.Sort((t1, t2) => t1.DueDate.CompareTo(t2.DueDate));

            for (int i = 0; i < tasks.Count; i++)
            {
                Task task = tasks[i];
                Console.WriteLine("{0,-3} {1,-30} {2,-20:dd/MM/yyyy} {3,-10}", i + 1, task.Title, task.DueDate, task.IsCompleted ? "Yes" : "No");
            }
        }
    }

    static void CompleteTask(List<Task> tasks)
    {
        ShowTask(tasks);

        Console.Write("Enter the ID of the task you want to mark complete: ");
        int taskId = int.Parse(Console.ReadLine());

        Task task = tasks[taskId - 1];
        task.IsCompleted = true;

        Console.WriteLine("Task \"{0}\" marked as complete.", task.Title);
    }
}