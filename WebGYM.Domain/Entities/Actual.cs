using WebGYM.Domain.Entities;

namespace WebGYM.Models
{
    public class Actual : BaseEntity
    {
        public string? Category { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Day { get; set; }

    }
}
