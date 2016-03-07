using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaoBei.Models;
using SaoBei.Negocio;

namespace SaoBei.Controllers
{
    public class IntegrantesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Integrantes
        public ActionResult Index(string sortOrder, string filtroAtual,
                                    string filtro, int? page,
                                    string ativoFiltro,
                                    string ativoFiltroAtual)
        {
            try
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NomeSort = string.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";

                if (filtro != null)
                {
                    page = 1;
                }
                else
                {
                    filtro = filtroAtual;
                }

                if (ativoFiltro != null)
                {
                    page = 1;
                }
                else
                {
                    ativoFiltro = ativoFiltroAtual;
                }

                ViewBag.FiltroAtual = filtro;

                IntegranteBll integranteBll = new IntegranteBll();

                return View("~/Views/Integrantes/Index.cshtml", integranteBll.BuscarIntegrantes(page, filtro, sortOrder, ativoFiltro, 10));
            }
            catch (Exception exception)
            {
                //LogBll.GravarErro(exception, User.Identity.Name);
                return View("~/Views/Integrantes/Index.cshtml").ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }
        }
        
        //GET
        public ActionResult Integrante(int? id)
        {
            Integrante integrante;

            if (id == null)
            {
                integrante = new Integrante();
            }
            else
            {
                integrante = db.Integrantes.Find(id);                
            }

            return View(integrante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Integrante([Bind(Include = "ID,Nome,Telefone,Email,Ativo")] Integrante integrante)
        {
            if (ModelState.IsValid)
            {
                if (integrante.ID > 0)
                {
                    db.Entry(integrante).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index").ComMensagem(Resources.Integrantes.IntegranteSalvo, TipoMensagem.Sucesso);
                }
                else
                {
                    db.Integrantes.Add(integrante);
                    db.SaveChanges();
                    return RedirectToAction("Index").ComMensagem(Resources.Integrantes.IntegranteSalvo, TipoMensagem.Sucesso);
                }                
            }
            return View(integrante);
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
