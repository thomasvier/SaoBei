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
using Chart.Mvc.ComplexChart;

namespace SaoBei.Controllers
{
    public class MensalidadesController : Controller
    {
        // GET: Index
        public ActionResult Index(int? calendarioId)
        {
            try
            {
                IEnumerable<string> Labels;
                IEnumerable<ComplexDataset> Datasets;
                List<Calendario> calendarios = CalendarioBll.ListarCalendarios().ToList();
                MensalidadeIntegranteBll.GraficoMensalidadeIntegrante(DateTime.Now.Year, out Labels, out Datasets);

                ViewBag.Labels = Labels;
                ViewBag.Datasets = Datasets;
                ViewBag.Calendarios = calendarios;

                MensalidadeIntegrante mensalidade = new MensalidadeIntegrante();

                mensalidade.CalendarioID = calendarios.Where(c => c.Ano == DateTime.Now.Year).FirstOrDefault().ID;

                return View(mensalidade);
            }
            catch(Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return View();
            }
        }

        public ActionResult Mensalidade(int? CalendarioID)
        {
            try
            {
                List<Calendario> calendarios = CalendarioBll.ListarCalendarios().ToList();

                ViewBag.Calendarios = calendarios;

                MensalidadeIntegrante mensalidades = new MensalidadeIntegrante();

                if (calendarios.Count > 0)
                {
                    if (CalendarioID > 0)
                    {
                        mensalidades.CalendarioID = calendarios.Where(c => c.ID == CalendarioID).FirstOrDefault().ID;
                    }
                    else
                    {
                        mensalidades.CalendarioID = calendarios.Where(c => c.Ano == DateTime.Now.Year).FirstOrDefault().ID;
                    }
                }

                List<Integrante> integrantes = IntegranteBll.RetornarIntegrantesAtivos().ToList();

                ViewBag.Integrantes = integrantes;

                return View(mensalidades);
            }
            catch(Exception exception)
            {
                LogBll.GravarErro(exception, this.User.Identity.Name);
                return View().ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }
        }

        public ActionResult BaixarMensalidades(int? integranteID, int? calendarioID)
        {
            try
            {
                List<MensalidadeIntegrante> mensalidadesIntegrante = MensalidadeIntegranteBll.RetornarMensalidadesIntegranteCalendario(integranteID, calendarioID).ToList();
                //Integrante integrante = IntegranteBll.RetornarIntegranteMensalidades(integranteID, calendarioID);
                return PartialView(mensalidadesIntegrante);
            }
            catch (Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return RedirectToAction("Index").ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BaixarMensalidades([Bind(Include = "ID,Mes,DataPagamento")] IEnumerable<MensalidadeIntegrante> mensalidadesIntegrante)
        {
            return View();
        }
    }
}