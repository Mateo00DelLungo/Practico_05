using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DetalleRepository : IRepository<TDetalle>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDetalle>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TDetalle> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(TDetalle entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TDetalle entity)
        {
            throw new NotImplementedException();
        }
    }
}
