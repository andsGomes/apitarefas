using TarefasAPI.Domain.Model;

namespace TarefasAPI.Domain.DTOs
{
    public class TarefasDto
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? status { get; set; }
        public DateTime? deletedAt { get; set; }

    }
}
