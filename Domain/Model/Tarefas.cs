using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasAPI.Domain.Model
{
    [Table("tarefas")]
    public class Tarefas 
    {
        [Key]
        public int id { get; set; }
        public string? title { get; set; }
        public string? status { get; set; }
        public DateTime? deletedAt { get; set; }

    }
}
