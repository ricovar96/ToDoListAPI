namespace ToDoListAPI.Models
{
    public class ToDoList
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime EndDate { get; set; }
        public int IsUrgent { get; set; }
        public int LevelImportance { get; set; }
    }
}
