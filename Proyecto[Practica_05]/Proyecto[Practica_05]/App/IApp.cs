using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.App
{
    public interface IApp
    {
        IManager<ServicioDTO> servicioManager { get; set; }
        IManagerTurno turnoManager { get; set; }
        IManager<DetalleDTO> detalleManager { get; set; }
    }
}
