namespace Daijou
{
    class Program
    {

        public static List<Task> userTasks = new List<Task>();
        public static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                        + "/tasks.txt";

        public static int taskIDCount = 0;

        static void Main(string[] args)
        {
            LoadDataFromFile();

            var menu = new Menu(userTasks);
            menu.PrintMenu();
        }

        public static void LoadDataFromFile()
        {
            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();
                List<int> taskIDCountList = new List<int>();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(",");
                    userTasks.Add(new Task(int.Parse(entries[0]), entries[1]));
                    taskIDCountList.Add(int.Parse(entries[0]));
                }
                if (taskIDCountList.Any()) taskIDCount = taskIDCountList.Max();
            }
        }

        public static void SaveDataToFile()
        {
            List<string> output = new List<string>();
            foreach (var task in userTasks)
            {
                output.Add($"{task.taskID},{task.taskName}");
            }
            File.WriteAllLines(filePath, output);
        }

        public static void EditTask()
        {
            Console.Write("Enter the task ID: ");
            int taskID = int.Parse(Console.ReadLine());

            try
            {
                userTasks.Remove(userTasks.Single(r => r.taskID == taskID));
                Console.Write("Enter an updated task description: ");
                string newTask = Console.ReadLine();
                userTasks.Add(new Task(taskID, newTask));
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message + "\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        public static void RemoveTask()
        {
            Console.Write("Enter the Id for the task you'd like to REMOVE: ");
            int taskID = int.Parse(Console.ReadLine());

            try
            {
                userTasks.Remove(userTasks.Single(r => r.taskID == taskID));
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message + "\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        public static void AddTask()
        {
            try
            {
                Console.Write("Enter the task name: ");
                string newTask = Console.ReadLine();
                userTasks.Add(new Task(taskIDCount++, newTask));
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message + "\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        public static void ViewTaskDetails()
        {
            Console.Write("Enter the task ID: ");
            int taskID = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine("text");
                Console.Write($"{userTasks.ElementAt(taskID)}");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message + "\nPress any key to continue..");
                Console.ReadKey();
            }
        }
    }
}
