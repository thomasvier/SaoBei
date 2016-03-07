using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaoBei.Models;

namespace SaoBei.Controllers
{
    public class CalendariosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Calendarios
        public ActionResult Index()
        {
            return View(db.Calendarios.ToList());
        }       

        // GET
        public ActionResult Calendario(int? id)
        {
            Calendario calendario;
 
            if (id == null)
            {
                calendario = new Calendario();                
            }
            else
            {
                calendario = db.Calendarios.Find(id);                
            }

            return View(calendario);
        }

        // POST: Calendarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calendario([Bind(Include = "ID,Ano,Janeiro,Fevereiro,Marco,Abril,Maio,Junho,Julho,Agosto,Setembro,Outubro,Novembro,Dezembro,ValorMensalidade,ValorAnuidade")] Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                if (calendario.ID > 0)
                {
                    db.Entry(calendario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index").ComMensagem(Resources.Calendario.CalendarioAtualizado, TipoMensagem.Sucesso);
                }
                else
                {
                    db.Calendarios.Add(calendario);
                    db.SaveChanges();
                    return RedirectToAction("Index").ComMensagem(Resources.Calendario.CalendarioSalvo, TipoMensagem.Sucesso);
                }
            }
            return View(calendario);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
