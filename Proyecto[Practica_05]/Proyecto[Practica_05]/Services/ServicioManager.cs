using Data.Models;
using Data.Repositories;
using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Services
{
    public class ServicioManager : IManager<ServicioDTO>
    {
        private readonly IRepository<TServicio> _repository;
        private readonly IMapper<ServicioDTO,TServicio> _mapper;
        public ServicioManager(IRepository<TServicio> repo,
            IMapper<ServicioDTO,TServicio> mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }
        public async Task<bool> Save(ServicioDTO dto)
        {
            var value = _mapper.Set(dto);
            return await _repository.Save(value);
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
        public async Task<List<ServicioDTO>> GetAll()
        {
            return _mapper.Get(await _repository.GetAll());
        }
        public async Task<ServicioDTO> GetById(int id)
        {
            return _mapper.Get(await _repository.GetById(id));
        }
        public async Task<bool> Update(int id, ServicioDTO dto)
        {
            var value = _mapper.Set(dto);
            value.Id = id;
            return await _repository.Update(value);
        }
    }
}
