using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Domain.DTOs;
using TarefasAPI.Repositories;

namespace TarefasAPI.Controllers
{
    [Route("api/[controller]/v1")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasRepositories _tarefas;

        public TarefasController(ITarefasRepositories tarefas)
        {
            _tarefas = tarefas;
        }

        [HttpGet]
        public async Task<ActionResult<TarefasDto>> Get()
        {
            var tarefas = await _tarefas.Get();
            if (tarefas == null) return NotFound();
            return Ok(tarefas);
        }

        [HttpGet("all")]
        public async Task<ActionResult<TarefasDto>> GetAll()
        {
            var tarefas = await _tarefas.GetAll();
            return Ok(tarefas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TarefasDto>> GetById(int id)
        {
            var tarefas = await _tarefas.GetById(id);
            Console.WriteLine(tarefas);
            if (tarefas == null) return NotFound();
            return Ok(tarefas);

        }

        [HttpPost]
        public async Task<ActionResult<TarefasDto>> Create([FromBody] TarefasDto dto)
        {
            if (dto == null) return BadRequest();
            var tarefa = await _tarefas.Create(dto);
            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<ActionResult<TarefasDto>> Update([FromBody] TarefasDto dto)
        {
            if (dto == null) return BadRequest();
            var tarefa = await _tarefas.Update(dto);
            return Ok(tarefa);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateId(int id)
        {
            bool suscesso = await _tarefas.UpdateId(id);
            if (!suscesso) return NotFound();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool sucesso = await _tarefas.Delete(id);

            if (!sucesso) return BadRequest();

            return Ok();
        }

        [HttpDelete("remove/{id}")]

        public async Task<ActionResult> DeleteById(int id)
        {
            var tarefa = await _tarefas.DeleteById(id);
            if (!tarefa) return BadRequest(); 
            return Ok(tarefa);
        }

    }
}
