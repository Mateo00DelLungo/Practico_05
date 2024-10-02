using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ServicioRepository : IRepository<TServicio>
    {
        private readonly TurnoDbContext _context;
        public ServicioRepository(TurnoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var delete = _context.TServicios.Find(id);
            if(delete == null) { return false; }
            _context.TServicios.Remove(delete);
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _context.TServicios.ToListAsync();
        }

        public async Task<TServicio> GetById(int id)
        {
            return await _context.TServicios.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Save(TServicio value)
        {
            _context.TServicios.Add(value);
            return 1 == await _context.SaveChangesAsync();
        }
        public async Task<bool> Update(TServicio updated)
        {
            var current = _context.TServicios.Find(updated.Id);
            if (current == null) { return false; }
            current.Nombre = updated.Nombre;
            current.Costo = updated.Costo;
            current.EnPromocion = updated.EnPromocion;
            return 1 == await _context.SaveChangesAsync();
        }
    }
}
