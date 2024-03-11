using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasAPI.Domain.Model
{
    [Table("usuarios")]
    public class Usuarios 
    {
        [Key]
        public int id { get; set; }
        public string? nome { get; set; }
        public string? cpf { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
