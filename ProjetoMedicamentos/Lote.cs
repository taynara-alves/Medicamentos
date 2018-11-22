using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public int Id
        {
            get
            {return id;}

            set
            {id = value;}
        }

        public int Qtde
        {
            get
            {return qtde;}

            set
            {qtde = value;}
        }

        public DateTime Venc
        {
            get
            { return venc;}

            set
            {venc = value;}
        }
        public Lote():this(0,0,new DateTime())
        {
            
        }
        public Lote(int _id,int _qtde,DateTime _venc)
        {
            this.id = _id;
            this.qtde = _qtde;
            this.venc = _venc;
        }
        public override string ToString()
        {
            return this.id.ToString() + " " +
                this.qtde.ToString() + " " +
                this.venc.ToShortDateString();
        }


    }
}
