namespace Daijou
{
    class Task
    {
        public Task(int taskID, string taskName)
        {
            this.taskID = taskID;
            this.taskName = taskName;
        }
        public int taskID { get; set; }
        public string taskName { get; set; }
    }
}
