namespace Daijou
{
    class Task
    {
        public Task(int taskID, string taskName, string description, DateTime date)
        {
            this.taskID = taskID;
            this.taskName = taskName;
			this.description = description;
			this.date = date;
        }
        public int taskID { get; set; }
        public string taskName { get; set; }
		public string description { get; set; }
		public DateTime date { get; set; }
    }
}
