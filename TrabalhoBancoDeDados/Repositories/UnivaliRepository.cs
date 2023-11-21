using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrabalhoBancoDeDados.api.DbContexts;
using TrabalhoBancoDeDados.api.Entities;

namespace TrabalhoBancoDeDados.api.Repositories
{
    public class UnivaliRepository : IUnivaliRepository
    {

        private readonly UnivaliContext _context;
        private readonly IMapper _mapper;

        public UnivaliRepository (UnivaliContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void AddBloco(Bloco bloco)
        {
            await _context.Blocos.AddAsync(bloco);
        }

        public async void AddSala(Sala sala)
        {
            await _context.Salas.AddAsync(sala);
        }

        public async void AddUniversidade(Universidade universidade)
        {
            await _context.Universidades.AddAsync(universidade);
        }

        public void DeleteBloco(Bloco bloco)
        {
            _context.Blocos.Remove(bloco);
        }

        public void DeleteSala(Sala sala)
        {
            _context.Salas.Remove(sala);
        }

        public void DeleteUniversidade(Universidade universidade)
        {
            _context.Universidades.Remove(universidade);
        }

        public async Task<Bloco?> GetBlocoByIdAsync(int blocoId)
        {
            return await _context.Blocos.FirstOrDefaultAsync(b => b.Id == blocoId);
        }

        public async Task<IEnumerable<Bloco>> GetBlocosWithSalasAsync()
        {
            return await _context.Blocos.OrderBy(b => b.Id).Include(b => b.Salas).ToListAsync();
        }

        public async Task<Sala?> GetSalaByIdAsync(int salaId)
        {
            return await _context.Salas.FirstOrDefaultAsync(s => s.Id == salaId);
        }

        public async Task<IEnumerable<Sala>> GetSalasAsync()
        {
            return await _context.Salas.OrderBy(s => s.Id).ToListAsync();
        }

        public async Task<Universidade?> GetUniversidadeByIdAsync(int universidadeId)
        {
            return await _context.Universidades.FirstOrDefaultAsync(u => u.Id == universidadeId);
        }

        public async Task<IEnumerable<Universidade>> GetUniversidadesWithBlocosAsync()
        {
            return await _context.Universidades.OrderBy(u => u.Id)
                .Include(u => u.Blocos)
                .ThenInclude(b => b.Salas)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
