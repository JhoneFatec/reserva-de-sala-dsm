using reserva_de_sala_dsm.Interfaces;
using reserva_de_sala_dsm.Models;

namespace reserva_de_sala_dsm.Services
{
    public class SalaService : ISalaService
    {
        public SalaService(ISalaRepository salaRepository) 
        {
            _salaRepository = salaRepository;
        }
        public Task DeleteSalaAsync(long id)
        {
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Sala>> GetAllSalasAsync()
        {
            return await _salaRepository.GetAllAsync();
        }

        public Task<Sala> GetSalaByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Sala> SaveSalaAsync(Sala sala)
        {
            if(sala.Id == 0)
            {
                await _salaRepository.AssAsync(sala);
            }
            else
            {
                _salaRepository.Update(sala);
            }

            await _salaRepository.
        }
    }
}
