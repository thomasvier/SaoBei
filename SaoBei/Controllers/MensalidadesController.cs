﻿using System;
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

                if (calendarioId > 0)
                {
                    mensalidade.CalendarioID = (int)calendarioId;
                }
                else
                {
                    mensalidade.CalendarioID = calendarios.Where(c => c.Ano == DateTime.Now.Year).FirstOrDefault().ID;
                }

                return View(mensalidade);
            }
            catch(Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return View();
            }
        }

        public ActionResult Mensalidade(int? CalendarioID, int? IntegranteID)
        {
            try
            {
                List<Calendario> calendarios = CalendarioBll.ListarCalendarios().ToList();
                List<Integrante> integrantes = IntegranteBll.RetornarIntegrantesAtivos().ToList();

                ViewBag.Calendarios = calendarios;
                ViewBag.Integrantes = integrantes;
                ViewBag.Integrantes = integrantes;

                IList<MensalidadeIntegrante> mensalidades = new List<MensalidadeIntegrante>();

                if (calendarios.Count > 0 && IntegranteID > 0)
                {
                    mensalidades = MensalidadeIntegranteBll.RetornarMensalidadesIntegranteCalendario(IntegranteID, CalendarioID).ToList();
                }

                return View(mensalidades);
            }
            catch(Exception exception)
            {
                LogBll.GravarErro(exception, this.User.Identity.Name);
                return View().ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }
        }

        public ActionResult BaixarMensalidades(int? mensalidadeIntegranteID)
        {
            try
            {
                MensalidadeIntegrante mensalidade = MensalidadeIntegranteBll.RetornarMensalidadeIntegranteCalendario(mensalidadeIntegranteID);
                ViewBag.Nome = IntegranteBll.RetornarIntegrante(mensalidade.IntegranteID).Nome;

                //Integrante integrante = IntegranteBll.RetornarIntegranteMensalidades(integranteID, calendarioID);
                return PartialView(mensalidade);
            }
            catch (Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return RedirectToAction("Index").ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BaixarMensalidades([Bind(Include = "ID,Mes,CalendarioID,IntegranteID,DataPagamento")] MensalidadeIntegrante mensalidadeIntegrante)
        {
            try
            {
                MensalidadeIntegranteBll mensalidadeIntegranteBll = new MensalidadeIntegranteBll();

                mensalidadeIntegranteBll.Atualizar(mensalidadeIntegrante);

                return RedirectToAction("Mensalidade", "Mensalidades");
            }
            catch(Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return RedirectToAction("Mensalidade", "Mensalidades");
            }
        }
    }
}