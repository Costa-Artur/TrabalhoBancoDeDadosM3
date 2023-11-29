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

            if(universidadesFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(universidadesFromDatabase.ToList());
        }

        [HttpGet("universidades/{universidadeId}")]
        public async Task<ActionResult<IEnumerable<Universidade>>> GetUniversidadeById(int universidadeId)
        {
            var universidadeFromDatabase = await _univaliRepository.GetUniversidadeByIdAsync(universidadeId);

            if (universidadeFromDatabase == null)
            {
                return NotFound();
            }

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
        public async Task<ActionResult<Sala>> GetSalas () {
            var salasFromDatabase = await _univaliRepository.GetSalasAsync();

            if(salasFromDatabase == null) {
                return NotFound();
            }

            return Ok(salasFromDatabase);
        }   

        [HttpGet("salas/{salaId}")]
        public async Task<ActionResult<Sala>> GetSalaById (int salaId) {
            var salaFromDatabase = await _univaliRepository.GetSalaByIdAsync(salaId);

            if(salaFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(salaFromDatabase);
        }

        [HttpPost("salas")]
        public async Task<ActionResult<Sala>> CreateSala (Sala sala) 
        {
            _univaliRepository.AddSala(sala);
            await _univaliRepository.SaveChangesAsync();
            var salaToReturn = await _univaliRepository.GetSalaByIdAsync(sala.Id);
            return Ok(salaToReturn);
        }

        [HttpPut("salas")]
        public async Task<ActionResult<Sala>> UpdateSala (Sala sala)
        {
            var salaFromDatabase = await _univaliRepository.GetSalaByIdAsync(sala.Id);
            if(salaFromDatabase == null) {
                return NotFound();
            }

            _mapper.Map(sala, salaFromDatabase);

            await _univaliRepository.SaveChangesAsync();

            var salaToReturn = await _univaliRepository.GetSalaByIdAsync(sala.Id);
            return Ok(salaToReturn);
        }

        [HttpDelete("salas/{salaId}")]
        public async Task<ActionResult> DeleteSala (int salaId)
        {
            var salaFromDatabase = await _univaliRepository.GetSalaByIdAsync(salaId);

            if(salaFromDatabase == null)
            {
                return NotFound();
            }
            _univaliRepository.DeleteSala(salaFromDatabase);
            await _univaliRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
