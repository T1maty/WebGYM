namespace WebGYM.Models
{
    public class Activities : BaseObject
    {
        public string? Category { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Day { get; set; }

    }
}
