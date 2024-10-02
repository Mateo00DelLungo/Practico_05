using Proyecto_Practica_05_.Interfaces;

namespace Proyecto_Practica_05_.Models
{
    public class DetalleDTO : IDataTransferObject
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
