using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Services
{
    public class TurnoManager : IManagerTurno
    {
        private readonly IMapper<TurnoDTO, TTurno> _mapper;
        private readonly ITurnoRepository _repository;
        public TurnoManager(IMapper<TurnoDTO, TTurno> mapper, ITurnoRepository repo)
        {
            _repository = repo;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<TurnoDTO>> GetAll()
        {
            return _mapper.Get(await _repository.GetAll());
        }

        public async Task<TurnoDTO> GetById(int id)
        {
            return _mapper.Get( await _repository.GetById(id));
        }
        public async Task<List<TurnoDTO>> GetByDate(DateTime date)
        {
            return _mapper.Get(await _repository.GetByDate(date));
        }
        public async Task<bool> Save(TurnoDTO dto)
        {
            return await _repository.Save(_mapper.Set(dto));
        }

        public async Task<bool> Update(int id, TurnoDTO dto)
        {
            var value = _mapper.Set(dto);
            value.Id = id;
            return await _repository.Update(value);
        }
    }
}
