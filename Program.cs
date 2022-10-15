using System.Threading.Tasks;

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
            menu.LoadMenu();
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
                    userTasks.Add(new Task(int.Parse(entries[0]), entries[1],
                                           entries[2], DateTime.Parse(entries[3])));
                    taskIDCountList.Add(int.Parse(entries[0]));
                }
                if (taskIDCountList.Any()) taskIDCount = taskIDCountList.Count();
            }
        }

        public static void SaveDataToFile()
        {
            List<string> output = new List<string>();
            foreach (var task in userTasks)
            {
                output.Add($"{task.taskID},{task.taskName},{task.description},{task.date}");
            }
            File.WriteAllLines(filePath, output);
        }

        public static void EditTask(int index)
        {
            int taskID = index;

            try
            {
                userTasks.Remove(userTasks.Single(r => r.taskID == taskID));
                Console.Write("Enter an updated task name: ");
                string newTaskName = Console.ReadLine();

                Console.Write("Enter task description: ");
                string newTaskDescription = Console.ReadLine();

                Console.Write("Enter task day: ");
                string newTaskDateDayInput = Console.ReadLine();
                int newTaskDateDay = Convert.ToInt32(newTaskDateDayInput);

                Console.Write("Enter task month: ");
                string newTaskDateMonthInput = Console.ReadLine();
                int newTaskDateMonth = Convert.ToInt32(newTaskDateMonthInput);

                Console.Write("Enter task year: ");
                string newTaskDateYearInput = Console.ReadLine();
                int newTaskDateYear = Convert.ToInt32(newTaskDateYearInput);

                DateTime newTaskDueDate = new DateTime(newTaskDateYear, newTaskDateMonth, newTaskDateDay);
                userTasks.Add(new Task(taskID, newTaskName, newTaskDescription, newTaskDueDate));
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
                string newTaskName = Console.ReadLine();

				Console.Write("Enter task description: ");
				string newTaskDescription = Console.ReadLine();
				
                Console.Write("Enter task day: ");
				string newTaskDateDayInput = Console.ReadLine();
                int newTaskDateDay = Convert.ToInt32(newTaskDateDayInput);

                Console.Write("Enter task month: ");
				string newTaskDateMonthInput = Console.ReadLine();
                int newTaskDateMonth = Convert.ToInt32(newTaskDateMonthInput);
				
                Console.Write("Enter task year: ");
				string newTaskDateYearInput = Console.ReadLine();
                int newTaskDateYear = Convert.ToInt32(newTaskDateYearInput);

                DateTime newTaskDueDate = new DateTime(newTaskDateYear, newTaskDateMonth, newTaskDateDay);
                userTasks.Add(new Task(taskIDCount++, newTaskName, newTaskDescription, newTaskDueDate));
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message + "\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        public static void ViewTaskDetails(int index)
        {
            int taskID = index;

            try
            {
                Console.WriteLine("--------------------------\n" +
                                  $"Date: {userTasks.ElementAt(taskID).date}\n" +
                                  $"--------------------------\n");
                Console.Write($"Task: {userTasks.ElementAt(taskID).taskName}\n" +
                              $"Description: {userTasks.ElementAt(taskID).description}");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message + "\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        public static List<Task> SortByDate(DateTime date)
        {
            List<Task> orderedList = userTasks;
            orderedList = userTasks.Where(o => o.date == date).ToList();

            /*foreach (var task in orderedList)
            {
                Console.WriteLine($"{task.taskID}\t{task.taskName}\t{task.description}\t{task.date}");
            }*/
			
			return orderedList;
        }
    }
}
