using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }
        public List<Medicamento> ListaMedicamentos
        {
            get { return listaMedicamentos; }
        }

        public bool adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
            return true;
        }

        public bool deletar(Medicamento medicamento)
        {
            if (medicamento.qtDisponivel() == 0)
            {
                listaMedicamentos.Remove(medicamento);
                return true;
            }
            return false;
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento medicPesq in this.listaMedicamentos)
            {
                if (medicPesq.Id.Equals(medicamento.Id))
                    return medicPesq;
            }
            return new Medicamento();

        }
    }
}
