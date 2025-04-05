namespace ToDoListAPI.DTOs
{
    public class ToDoListDTO
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsUrgent { get; set; }
        public int LevelImportance { get; set; }
    }
}
