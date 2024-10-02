using Proyecto_Practica_05_.Interfaces;

namespace Proyecto_Practica_05_.Models
{
    public class ServicioDTO : IDataTransferObject
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Costo { get; set; }
        public bool EnPromocion { get; set; }

        public bool Validate()
        {
            if(Id < 0 || string.IsNullOrEmpty(Nombre) || Costo <= 0)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"Servicio: {Nombre} : ${Costo}. En promocion: {EnPromocion}";
        }
    }
}
