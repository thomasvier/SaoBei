using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using SaoBei.Models;
using System.Data.Entity;

namespace SaoBei.Negocio
{
    public class IntegranteBll
    {
        Contexto db;

        public IntegranteBll()
        {
            db = new Contexto();
        }

        public IPagedList<Integrante> BuscarIntegrantes(int? page, string filtro,
                                            string sortOrder, string ativoFiltro, int pageSize)
        {
            int ativo = int.TryParse(ativoFiltro, out ativo) ? ativo : 2;

            var integrantes = from i in db.Integrantes
                         select i;

            if (!String.IsNullOrEmpty(filtro))
            {
                integrantes = integrantes.Where(i => i.Nome.Contains(filtro));
            }

            if (ativo < 2)
            {
                bool situacao = ativo.Equals(0) ? false : true;
                integrantes = integrantes.Where(x => x.Ativo == situacao);
            }
            
            switch (sortOrder)
            {
                case "nome_desc":
                    integrantes = integrantes.OrderByDescending(s => s.Nome);
                    break;
                default:
                    integrantes = integrantes.OrderBy(s => s.Nome);
                    break;
            }

            int pageNumber = (page ?? 1);

            return integrantes.ToPagedList(pageNumber, pageSize);
        }

        public Integrante Criar(Integrante integrante)
        {
            db.Integrantes.Add(integrante);
            db.SaveChanges();

            return integrante;
        }

        public Integrante Atualizar(Integrante integrante)
        {
            db.Entry(integrante).State = EntityState.Modified;
            db.SaveChanges();

            return integrante;
        }

        public static Integrante RetornarIntegrante(int? id)
        {
            Contexto db = new Contexto();

            Integrante integrante = db.Integrantes.Where(i => i.ID == id).FirstOrDefault();

            return integrante;
        }
    }
}