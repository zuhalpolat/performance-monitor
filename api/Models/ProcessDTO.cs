namespace performance_monitor.Models
{
    public class ProcessDTO
    {
        public ProcessDTO()
        {
            
        }

        public ProcessDTO(int ıd, string name, bool ısOnline)
        {
            Id = ıd;
            Name = name;
            IsOnline = ısOnline;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
    }
}