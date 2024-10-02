using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TurnoRepository : IRepository<TTurno>
    {
        private readonly TurnoDbContext _context;
        public TurnoRepository(TurnoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var deleted = _context.TTurnos.Find(id);
            if(deleted == null) { return false; }
            _context.TTurnos.Remove(deleted);
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _context.TTurnos.ToListAsync();
        }

        public async Task<TTurno> GetById(int id)
        {
            return await _context.TTurnos.FindAsync(id);
        }

        public async Task<bool> Save(TTurno entity)
        {
            var exists = _context.TTurnos.FirstOrDefault(p=> p.Fecha == entity.Fecha && p.Hora == entity.Hora);
            if (exists != null) { return false; }
            _context.TTurnos.Add(entity);
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(TTurno entity)
        {
            var current = _context.TTurnos.Find(entity.Id);
            if(current == null) { return false; }
            current.Fecha = entity.Fecha;
            current.Hora = entity.Hora;
            current.Cliente = entity.Cliente;
            return 1 == await _context.SaveChangesAsync();
        }
    }
}
