using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using SaoBei.Models;
using System.Data.Entity;

namespace SaoBei.Negocio
{
    public class JogoBll
    {
        Contexto db;

        public JogoBll()
        {
            db = new Contexto();
        }

        public IPagedList<Jogo> BuscarJogos(int? page, string filtro,
                                            string sortOrder, int pageSize)
        {
            var jogos = from a in db.Jogos
                              select a;
            
            
            switch (sortOrder)
            {
                case "adversario_desc":
                    jogos = jogos.OrderByDescending(j => j.Adversario.Nome);
                    break;
                default:
                    jogos = jogos.OrderBy(j => j.Adversario.Nome);
                    break;
            }

            int pageNumber = (page ?? 1);

            return jogos.ToPagedList(pageNumber, pageSize);
        }

        public static Jogo RetornarJogo(int? id)
        {
            Contexto db = new Contexto();

            Jogo jogo = db.Jogos.Where(j => j.ID == id).FirstOrDefault();

            return jogo;
        }

        public Jogo Criar(Jogo jogo)
        {
            db.Jogos.Add(jogo);
            db.SaveChanges();

            return jogo;
        }

        public Jogo Atualizar(Jogo jogo)
        {
            db.Entry(jogo).State = EntityState.Modified;
            db.SaveChanges();

            return jogo;
        }

        public static IQueryable<Jogo> RetornarJogosConfirmados()
        {
            Contexto db = new Contexto();
            IQueryable<Jogo> jogos = db.Jogos.Where(j => j.SituacaoJogo == SituacaoJogo.Confirmado);

            return jogos;
        }

        public static Jogo RetornarProximoJogoConfirmado()
        {
            Contexto db = new Contexto();

            Jogo jogo = db.Jogos.OrderBy(j => j.Data).FirstOrDefault();

            return jogo;
        }        
    }
}