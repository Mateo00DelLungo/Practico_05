using Data.Models;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Utils
{
    public class TurnoMapper:MapperBase<TurnoDTO,TTurno>
    {
        public TTurno Set(TurnoDTO dto)
        {
            if (dto == null) { return null; }
            return base.Set(dto);
        }
        public List<TTurno> Set(List<TurnoDTO> dtolst)
        {
            if (dtolst == null || dtolst.Count == 0) { return null; }
            return base.Set(dtolst);
        }
        public TurnoDTO Get(TTurno value)
        {
            if(value == null) { return null; }
            return base.Get(value);
        }
        public List<TurnoDTO> Get(List<TTurno> valuelst)
        {
            if (valuelst == null || valuelst.Count == 0) { return null; }
            return base.Get(valuelst);
        }
    }
}
