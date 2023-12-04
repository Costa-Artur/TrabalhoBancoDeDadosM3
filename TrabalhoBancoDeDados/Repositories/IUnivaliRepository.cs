using TrabalhoBancoDeDados.api.Entities;

namespace TrabalhoBancoDeDados.api.Repositories
{
    public interface IUnivaliRepository
    {
        Task<IEnumerable<Universidade>> GetUniversidadesWithBlocosAsync();
        Task<Universidade?> GetUniversidadeByIdAsync(int universidadeId);
        void AddUniversidade (Universidade universidade);
        Task<bool> SaveChangesAsync();
        void DeleteUniversidade(Universidade universidade);

        Task<IEnumerable<Bloco>> GetBlocosWithSalasAsync();
        Task<Bloco?> GetBlocoByIdAsync(int blocoId, int universidadeId);
        void AddBloco(Bloco bloco);
        void DeleteBloco(Bloco bloco);

        Task<IEnumerable<Sala>> GetSalasAsync();
        Task<Sala?> GetSalaByIdAsync(int salaId, int blocoId);
        void AddSala(Sala sala);
        void DeleteSala(Sala sala);

    }
}
