using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabalhoBancoDeDados.api.Entities;
using TrabalhoBancoDeDados.api.Repositories;

namespace TrabalhoBancoDeDados.api.Controllers
{
    [Route("api/univali")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnivaliRepository _univaliRepository;

        public SalasController(IMapper mapper, IUnivaliRepository univaliRepository)
        {
            _mapper = mapper;
            _univaliRepository = univaliRepository;
        }

        [HttpGet("universidades")]
        public async Task<ActionResult<IEnumerable<Universidade>>> GetUniversidades ()
        {
            var universidadesFromDatabase = await _univaliRepository.GetUniversidadesWithBlocosAsync();

            return Ok(universidadesFromDatabase.ToList());
        }

        [HttpGet("universidades/{universidadeId}")]
        public async Task<ActionResult<IEnumerable<Universidade>>> GetUniversidadeById(int universidadeId)
        {
            var universidadeFromDatabase = await _univaliRepository.GetUniversidadeByIdAsync(universidadeId);

            return Ok(universidadeFromDatabase);
        }

        [HttpDelete("universidades/{universidadeId}")]
        public async Task<ActionResult> DeleteUniversidade (int universidadeId)
        {
            var universidadeFromDatabase = await _univaliRepository.GetUniversidadeByIdAsync(universidadeId);

            if (universidadeFromDatabase == null)
            {
                return NotFound();
            }
            
            _univaliRepository.DeleteUniversidade(universidadeFromDatabase);

            return Ok();
        }

        [HttpPut("universidades")]
        public async Task<ActionResult<Universidade>> UpdateUniversidade (Universidade universidade)
        {
            
            var universidadeFromDatabase = await _univaliRepository.GetUniversidadeByIdAsync (universidade.Id);
            if(universidadeFromDatabase == null)
            {
                return NotFound();
            }

            _mapper.Map(universidade, universidadeFromDatabase);

            await _univaliRepository.SaveChangesAsync();

            var universidadeToReturn = await _univaliRepository.GetUniversidadeByIdAsync(universidade.Id);

            return Ok(universidadeToReturn);

        }

        [HttpPost("universidades")]
        public async Task<ActionResult<Universidade>> CreateUniversidade (Universidade universidade)
        {
            _univaliRepository.AddUniversidade(universidade);
            await _univaliRepository.SaveChangesAsync();
            var universidadeToReturn = await _univaliRepository.GetUniversidadeByIdAsync(universidade.Id);
            return Ok(universidadeToReturn);
        }

        [HttpGet("salas")]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSalas () {
            var salasFromDatabase = await _univaliRepository.GetSalasAsync();

            return Ok(salasFromDatabase);
        }   

        [HttpGet("salas/{salaId}/{blocoId}")]
        public async Task<ActionResult<Sala>> GetSalaById (int salaId, int blocoId) {
            var salaFromDatabase = await _univaliRepository.GetSalaByIdAsync(salaId, blocoId);

            return Ok(salaFromDatabase);
        }

        [HttpPost("salas")]
        public async Task<ActionResult<Sala>> CreateSala (Sala sala) 
        {
            _univaliRepository.AddSala(sala);
            await _univaliRepository.SaveChangesAsync();
            var salaToReturn = await _univaliRepository.GetSalaByIdAsync(sala.Id, sala.BlocoId);
            return Ok(salaToReturn);
        }

        [HttpPut("salas")]
        public async Task<ActionResult<Sala>> UpdateSala (Sala sala)
        {
            var salaFromDatabase = await _univaliRepository.GetSalaByIdAsync(sala.Id, sala.BlocoId);
            if(salaFromDatabase == null) {
                return BadRequest();
            }

            _mapper.Map(sala, salaFromDatabase);

            await _univaliRepository.SaveChangesAsync();

            var salaToReturn = await _univaliRepository.GetSalaByIdAsync(sala.Id, sala.BlocoId) ;
            return Ok(salaToReturn);
        }

        [HttpDelete("salas/{blocoId}/{salaId}")]
        public async Task<ActionResult> DeleteSala (int blocoId, int salaId )
        {
            var salaFromDatabase = await _univaliRepository.GetSalaByIdAsync(salaId, blocoId);

            if(salaFromDatabase == null)
            {
                return NotFound();
            }
            _univaliRepository.DeleteSala(salaFromDatabase);
            await _univaliRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("blocos")]
        public async Task<ActionResult<IEnumerable<Bloco>>> GetBlocos()
        {
            var blocosFromDatabase = await _univaliRepository.GetBlocosWithSalasAsync();

            return Ok(blocosFromDatabase);
        }

        [HttpGet("blocos/{universidadeId}/{blocoId}")]
        public async Task<ActionResult<Bloco>> GetBlocoById(int universidadeId, int blocoId)
        {
            var blocoFromDatabase = await _univaliRepository.GetBlocoByIdAsync(blocoId, universidadeId);

            return Ok(blocoFromDatabase);
        }

        [HttpPost("blocos")]
        public async Task<ActionResult<Bloco>> CreateBloco(Bloco bloco)
        {
            _univaliRepository.AddBloco(bloco);
            await _univaliRepository.SaveChangesAsync();
            var blocoFromDatabase = _univaliRepository.GetBlocoByIdAsync(bloco.Id, bloco.UniversidadeId);
            return Ok(blocoFromDatabase);
        }

        [HttpPut("blocos")]
        public async Task<ActionResult<Bloco>> UpdateBloco (Bloco bloco)
        {
            var blocoFromDatabase = await _univaliRepository.GetBlocoByIdAsync(bloco.Id, bloco.UniversidadeId);
            if(blocoFromDatabase == null)
            {
                return BadRequest();
            }

            _mapper.Map(bloco, blocoFromDatabase);
            await _univaliRepository.SaveChangesAsync();
            
            var blocoToReturn = await _univaliRepository.GetBlocoByIdAsync(bloco.Id, bloco.UniversidadeId);
            return Ok(blocoToReturn);
        }

        [HttpDelete("blocos/{universidadeId}/{blocoId}")]
        public async Task<ActionResult> DeleteBloco (int universidadeId, int blocoId)
        {
            var blocoFromDatabase = await _univaliRepository.GetBlocoByIdAsync(blocoId, universidadeId);
            if(blocoFromDatabase == null)
            {
                return BadRequest();
            }

            _univaliRepository.DeleteBloco(blocoFromDatabase);
            await _univaliRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
