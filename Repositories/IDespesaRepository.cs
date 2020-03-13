using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Mobills.Models;

namespace WebApi_Mobills.Repositories
{
    interface IDespesaRepository
    {
        IEnumerable<Despesa> GetAll();
        Despesa Get(int id);
        Despesa Create(Despesa despesa);
        void Delete(int id);
        bool Update(Despesa despesa);
    }
}
