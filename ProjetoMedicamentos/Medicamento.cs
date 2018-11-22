using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id
        {
            get
            { return id; }

            set
            { id = value; }
        }

        public string Nome
        {
            get
            { return nome; }

            set
            { nome = value; }
        }

        public string Laboratorio
        {
            get
            { return laboratorio; }

            set
            { laboratorio = value; }
        }

        internal Queue<Lote> Lotes
        {
            get
            {
                return lotes;
            }

            set
            {
                lotes = value;
            }
        }

        public Medicamento():this(0,"","")
        {
            
            Lotes = new Queue<Lote>();
        }
        public Medicamento(int _id, string _nome, string _laboratorio)
        {
            this.Id = _id;
            this.Laboratorio = _laboratorio;
            this.Nome = _nome;
            Lotes = new Queue<Lote>();
        }
        public int qtDisponivel()
        {
            int qtdEstoque = 0;
            foreach (Lote lote in Lotes)
            {
                qtdEstoque += lote.Qtde;
            }
            return qtdEstoque;

        }
        public void comprar(Lote lote)
        {
            Lotes.Enqueue(lote);

        }
        public bool vender(int qtde)
        {
           
            if(qtDisponivel() >= qtde)
            {
                while(qtde > 0)
                {
                    if(qtde >= lotes.Peek().Qtde-1)
                    {
                        qtde -= Lotes.Dequeue().Qtde;
                    }
                    else
                    {
                        Lotes.Peek().Qtde -= qtde;
                    }

                }
                return true;
            }
            return false;
            
        }
        public override string ToString()
        {
            return "ID:"+id + " \nNome: " + nome + " \nLaboratorio: " + laboratorio + " \nQuantidade: " + qtDisponivel();
        }
        /*
        public override bool Equals(object obj)
        {
            Medicamento medicamento = (Medicamento)obj;
            return this.id.Equals(medicamento.id);
        }
        */
        public override bool Equals(object obj)
        {
            return ((Medicamento)obj).id.Equals(this.id);
        }
    }
}
