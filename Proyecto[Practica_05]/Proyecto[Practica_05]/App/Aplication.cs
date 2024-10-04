using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.App
{
    public class Aplication : IApp
    {
        public IManager<ServicioDTO> servicioManager { get; set; }
        public IManager<DetalleDTO> detalleManager { get; set; }
        public IManagerTurno turnoManager { get; set; }

        public Aplication(IManager<ServicioDTO> sManager,
            IManager<DetalleDTO> dManager, IManagerTurno tManager)
        {
            servicioManager = sManager;
            detalleManager = dManager;
            turnoManager = tManager;
        }
    }
}
