using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TarefasAPI.Context;
using TarefasAPI.Domain.DTOs;
using TarefasAPI.Domain.Model;

namespace TarefasAPI.Repositories
{
    public class TarefasServico : ITarefasRepositories
    {
        private readonly TarefasDbContext _db;
        private readonly IMapper _mapper;

        public TarefasServico(TarefasDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<TarefasDto>> Get()
        {
            var tarefas = await _db.Tarefas.Where(t => t.deletedAt == null).ToListAsync();
            return _mapper.Map<List<TarefasDto>>(tarefas);

        }
        public async Task<List<TarefasDto>> GetAll()
        {
            var tarefas = await _db.Tarefas.ToListAsync();
            return _mapper.Map<List<TarefasDto>>(tarefas);
        }

        public async Task<TarefasDto> GetById(int id)
        {
            Tarefas? tarefa = await _db.Tarefas
                .Where(t => t.id == id)
                .FirstOrDefaultAsync();

            return tarefa != null ? _mapper.Map<TarefasDto>(tarefa) : null!;
        }
        public async Task<TarefasDto> Create(TarefasDto dto)
        {
            Tarefas tarefas = _mapper.Map<Tarefas>(dto);
            await _db.Tarefas.AddAsync(tarefas);
            await _db.SaveChangesAsync();
            return _mapper.Map<TarefasDto>(tarefas);
        }
        public async Task<TarefasDto> Update(TarefasDto dto)
        {
            Tarefas tarefa = _mapper.Map<Tarefas>(dto);
            _db.Tarefas.Update(tarefa);
            await _db.SaveChangesAsync();
            return _mapper.Map<TarefasDto>(tarefa);
        }

        public async Task<bool> UpdateId(int id)
        {
            try
            {
                Tarefas? tarefa = await _db.Tarefas.Where(t => t.id == id && t.status != "P").FirstOrDefaultAsync();
                if (tarefa == null) return false;

                tarefa.status = "P";
                tarefa.deletedAt = null;
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Tarefas? tarefa = await _db.Tarefas.Where(t => t.id == id).FirstOrDefaultAsync();
                if (tarefa == null) return false;
                tarefa.status = "C";
                tarefa.deletedAt = DateTime.UtcNow;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                Tarefas? tarefas = await _db.Tarefas.Where(t => t.id == id).FirstOrDefaultAsync();
                if (tarefas == null) return false;

                _db.Tarefas.Remove(tarefas);
                await _db.SaveChangesAsync(); 
                return true;
            } catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }

        }


    }
}
