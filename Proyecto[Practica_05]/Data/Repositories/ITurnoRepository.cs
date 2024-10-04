using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ITurnoRepository : IRepository<TTurno>
    {
        Task<List<TTurno>> GetByDate(DateTime date);
    }
}
