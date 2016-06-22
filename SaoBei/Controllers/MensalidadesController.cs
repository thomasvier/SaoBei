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
        public ActionResult Index()
        {
            IEnumerable<string> Labels;

            IEnumerable<ComplexDataset> Datasets;

            MensalidadesBll.GraficoMensalidades(DateTime.Now.Year, out Labels, out Datasets);

            ViewBag.Labels = Labels;
            ViewBag.Datasets = Datasets;

            return View();
        }

        public ActionResult GraficoMensalidadesMes()
        {
            

            return PartialView();
        }

        public ActionResult Mensalidade()
        {
            List<Calendario> calendarios = CalendarioBll.ListarCalendarios().ToList();

            ViewBag.Calendarios = calendarios;

            Mensalidades mensalidades = new Mensalidades();

            if (calendarios.Count > 0)
            {
                mensalidades.CalendarioID = calendarios.Where(c => c.Ano == DateTime.Now.Year).FirstOrDefault().ID;
            }

            List<Integrante> integrantes = IntegranteBll.RetornarIntegrantesAtivos().ToList();

            ViewBag.Integrantes = integrantes;

            return View(mensalidades);
        }
    }
}