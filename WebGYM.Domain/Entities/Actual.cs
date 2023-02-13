using WebGYM.Domain.Entities;

namespace WebGYM.Models
{
    public class Activition : BaseEntity
    {
        public string? Category { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Day { get; set; }

    }
}
