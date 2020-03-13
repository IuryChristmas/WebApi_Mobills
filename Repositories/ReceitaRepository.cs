using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Mobills.Models;

namespace WebApi_Mobills.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {

        private List<Receita> receitas = new List<Receita>();
        private int _nextId = 1;

        public ReceitaRepository()
        {
            Create(new Receita { Descricao = "Uber", Valor = 15.80m, Data = DateTime.Today, Recebido = false });
            Create(new Receita { Descricao = "iFood", Valor = 10.80m, Data = DateTime.Today, Recebido = false });
        }

        public Receita Create(Receita receita)
        {
            if (receita == null)
            {
                throw new ArgumentNullException("receita");
            }

            receita.Id = _nextId++;
            receitas.Add(receita);

            return receita;
        }

        public void Delete(int id)
        {
            receitas.RemoveAll(receita => receita.Id == id);
        }

        public Receita Get(int id)
        {
            return receitas.Find(receita => receita.Id == id);
        }

        public IEnumerable<Receita> GetAll()
        {
            return receitas;
        }

        public bool Update(Receita receitaNew)
        {
            if (receitaNew == null)
            {
                throw new ArgumentNullException("receita");
            }

            int index = receitas.FindIndex(receitaOld => receitaOld.Id == receitaNew.Id);

            if (index == -1)
            {
                return false;
            }

            receitas.RemoveAt(index);
            receitas.Add(receitaNew);
            return true;
        }
    }
}
