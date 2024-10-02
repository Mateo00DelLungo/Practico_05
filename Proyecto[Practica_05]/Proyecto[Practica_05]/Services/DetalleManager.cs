using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Services
{
    public class DetalleManager : IManager<DetalleDTO>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DetalleDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(DetalleDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, DetalleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
