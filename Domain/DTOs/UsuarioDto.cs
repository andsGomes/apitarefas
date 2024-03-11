namespace TarefasAPI.Domain.DTOs
{
    public class UsuarioDto
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? cpf { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
