using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public static Calendario RetornarCalendario(int? id)
        {
            Contexto db = new Contexto();

            Calendario calendario = db.Calendarios.Where(c => c.ID == id).FirstOrDefault();

            return calendario;
        }

        public static List<Calendario> ListarCalendarios()
        {
            Contexto db = new Contexto();

            List<Calendario> calendarios = db.Calendarios.OrderBy(c => c.Ano).ToList();

            return calendarios;
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
    }
}