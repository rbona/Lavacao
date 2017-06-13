using Lavacao.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavacao.DAL.Contexto
{
    public class BancoContexto : DbContext
    {
        public BancoContexto() : base("ConnDB") { }

        public DbSet<Carro> Carros { get; set; }
    }
}
