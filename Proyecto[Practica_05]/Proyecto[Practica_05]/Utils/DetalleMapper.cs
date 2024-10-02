using Data.Models;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Utils
{
    public class DetalleMapper:MapperBase<DetalleDTO, TDetalle>
    {
        public TDetalle Set(DetalleDTO dto)
        {
            return base.Set(dto);
        }
        public List<TDetalle> Set(List<DetalleDTO> dtolst)
        {
            return base.Set(dtolst);
        }
        public DetalleDTO Get(TDetalle value) 
        {
            return base.Get(value);
        }
        public List<DetalleDTO> Get(List<TDetalle> valuelst)
        {
            return base.Get(valuelst);
        }
    }
}
