using Data.Models;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Utils
{
    public class ServicioMapper : MapperBase<ServicioDTO, TServicio>
    {
        //SERVICIO
        public TServicio Set(ServicioDTO dto)
        {
            if(dto == null) return null;
            return base.Set(dto);
        }
        public List<TServicio> Set(List<ServicioDTO> dtolst)
        {
            if (dtolst == null || dtolst.Count == 0) return null;
            return base.Set(dtolst);
        }
        public ServicioDTO Get(TServicio value)
        {
            if(value == null) return null;
            return base.Get(value);
        }
        public List<ServicioDTO> Get(List<TServicio> valuelst)
        {
            if (valuelst == null || valuelst.Count == 0) return null;
            return base.Get(valuelst);
        }
    }
}
