using AutoMapper;
using TarefasAPI.Domain.DTOs;
using TarefasAPI.Domain.Model;

namespace TarefasAPI.Application.Mapping
{
    public class DomainDtoMapping : Profile
    {
        public DomainDtoMapping()
        {
            CreateMap<Tarefas, TarefasDto>();
            CreateMap<TarefasDto, Tarefas>();
            //CreateMap<Usuarios, UsuarioDto>();
            //CreateMap<UsuarioDto, Usuarios>();
        }
    }
}
