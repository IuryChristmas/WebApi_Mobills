using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Mobills.Models;

namespace WebApi_Mobills.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private List<Despesa> despesas = new List<Despesa>();
        private int _nextId = 1;

        public DespesaRepository()
        {
            Create(new Despesa { Descricao = "Uber", Valor = 15.80m, Data = DateTime.Today, Pago = true});
            Create(new Despesa { Descricao = "iFood", Valor = 10.80m, Data = DateTime.Today, Pago = false });
        }

        public Despesa Create(Despesa despesa)
        {
            if (despesa == null)
            {
                throw new ArgumentNullException("despesa");
            }

            despesa.Id = _nextId++;
            despesas.Add(despesa);

            return despesa;
        }

        public Despesa Get(int id)
        {
            return despesas.Find(despesa => despesa.Id == id);
        }

        public IEnumerable<Despesa> GetAll()
        {
            return despesas;
        }

        public void Delete(int id)
        {
            despesas.RemoveAll(despesa => despesa.Id == id);
        }

        public bool Update(Despesa despesaNew)
        {
            if (despesaNew == null)
            {
                throw new ArgumentNullException("despesa");
            }

            int index = despesas.FindIndex(despesaOld => despesaOld.Id == despesaNew.Id);

            if(index == -1)
            {
                return false;
            }

            despesas.RemoveAt(index);
            despesas.Add(despesaNew);
            return true;
        }
    }
}
