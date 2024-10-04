using Data.Models;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Interfaces
{
    public interface IManagerTurno : IManager<TurnoDTO>
    {
        Task<List<TurnoDTO>> GetByDate(DateTime date);
    }
}
