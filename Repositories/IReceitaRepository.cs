using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Mobills.Models;

namespace WebApi_Mobills.Repositories
{
    public interface IReceitaRepository
    {
        IEnumerable<Receita> GetAll();
        Receita Get(int id);
        Receita Create(Receita receita);
        void Delete(int id);
        bool Update(Receita receita);
    }
}
