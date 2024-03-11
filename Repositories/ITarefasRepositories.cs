using TarefasAPI.Domain.DTOs;

namespace TarefasAPI.Repositories
{
    public interface ITarefasRepositories
    {
        Task<List<TarefasDto>> Get();
        Task<List<TarefasDto>> GetAll();
        Task<TarefasDto> GetById(int id);
        Task<TarefasDto> Create(TarefasDto dto);
        Task<TarefasDto> Update(TarefasDto dto);
        Task<bool> UpdateId(int id);
        Task<bool> Delete(int id);
        Task<bool> DeleteById(int id);
    }
}
