using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using SaoBei.Models;
using System.Data.Entity;

namespace SaoBei.Negocio
{
    public class CalendarioBll
    {
        Contexto db;

        public CalendarioBll()
        {
            db = new Contexto();
        }

        public Calendario Criar(Calendario calendario)
        {
            db.Calendarios.Add(calendario);
            db.SaveChanges();

            return calendario;
        }

        public Calendario Atualizar(Calendario calendario)
        {
            db.Entry(calendario).State = EntityState.Modified;
            db.SaveChanges();

            return calendario;
        }

        public static Calendario RetornarCalendario(int? id)
        {
            Contexto db = new Contexto();

            Calendario calendario = db.Calendarios.Where(x => x.ID == id).FirstOrDefault();

            return calendario;
        }
    }
}