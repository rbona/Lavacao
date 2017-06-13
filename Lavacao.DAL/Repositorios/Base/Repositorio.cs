﻿using Lavacao.DAL.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavacao.DAL.Repositorios.Base
{
    public class Repositorio<TEntidade> : IDisposable, IRepositorio<TEntidade> where TEntidade : class
    {
        BancoContexto contexto = new BancoContexto();

        public void Adicionar(TEntidade objeto)
        {
            contexto.Set<TEntidade>().Add(objeto);
        }

        public void Atualizar(TEntidade objeto)
        {
            contexto.Entry(objeto).State = EntityState.Modified;
        }

        public IQueryable<TEntidade> Buscar(Func<TEntidade, bool> filtro)
        {
            return BuscarTodos().Where(filtro).AsQueryable();
        }

        public TEntidade BuscarChave(params object[] chave)
        {
            return contexto.Set<TEntidade>().Find(chave);
        }

        public IQueryable<TEntidade> BuscarTodos()
        {
            return contexto.Set<TEntidade>();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Excluir(Func<TEntidade, bool> filtro)
        {
            Buscar(filtro).ToList().ForEach(apagar => contexto.Set<TEntidade>().Remove(apagar));
        }

        public void Salvar()
        {
            contexto.SaveChanges();
        }
    }
}
