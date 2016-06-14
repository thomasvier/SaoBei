﻿using SaoBei.Models;
using SaoBei.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SaoBei.Controllers
{
    [Authorize(Roles = "Diretoria")]
    public class JogosController : Controller
    {
        // GET: Jogos
        public ActionResult Index(string sortOrder, string filtroAtual,
                                    string filtro, int? page, string dataInicio, 
                                    string dataFim, string dataInicioAtual, string dataFimAtual)
        {
            try
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.AdversarioSort = string.IsNullOrEmpty(sortOrder) ? "adversario_desc" : "";                

                if (filtro != null)
                {
                    page = 1;
                }
                else
                {
                    filtro = filtroAtual;
                }

                if(dataInicio != null)
                {
                    page = 1;
                }
                else
                {
                    dataInicio = dataInicioAtual;
                }

                if (dataFim != null)
                {
                    page = 1;
                }
                else
                {
                    dataFim = dataFimAtual;
                }

                ViewBag.FiltroAtual = filtro;
                ViewBag.DataInicio = dataInicio;
                ViewBag.DataFim = dataFim;

                JogoBll jogoBll = new JogoBll();

                return View("~/Views/Jogos/Index.cshtml", jogoBll.BuscarJogos(page, filtro, sortOrder, 10));
            }
            catch (Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return View("~/Views/Jogos/Index.cshtml").ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }            
        }

        //GET
        public ActionResult Jogo(int? id)
        {
            try
            {
                Jogo jogo;

                List<Adversario> adversarios = AdversarioBll.RetornarAdversariosAtivos().ToList();
                List<Calendario> calendarios = CalendarioBll.ListarCalendarios().ToList();
                                    
                ViewBag.Adversarios = adversarios;
                ViewBag.Calendarios = calendarios;

                if (id == null)
                {
                    jogo = new Jogo();
                    Calendario calendario = calendarios.Where(c => c.Ano == DateTime.Now.Year).FirstOrDefault();
                    jogo.CalendarioID = calendario.ID;
                }
                else
                {
                    jogo = JogoBll.RetornarJogo(id);
                }

                return View(jogo);
            }
            catch (Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return RedirectToAction("Index").ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Jogo([Bind(Include = "ID,Data,Hora,Local,AdversarioID,Adversario,CalendarioID,Calendario,SituacaoJogo,MotivoCancelamento")] Jogo jogo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JogoBll jogoBll = new JogoBll();

                    if (jogo.ID > 0)
                    {
                        jogoBll.Atualizar(jogo);
                        LogBll.GravarInformacao(string.Format(Resources.Jogos.AtualizacaoLog, jogo.ID), "", User.Identity.Name);
                        return RedirectToAction("Index").ComMensagem(Resources.Jogos.JogoSalvo, TipoMensagem.Sucesso);
                    }
                    else
                    {
                        jogoBll.Criar(jogo);
                        LogBll.GravarInformacao(string.Format(Resources.Calendario.CriacaoLog, jogo.ID), "", User.Identity.Name);
                        return RedirectToAction("Index").ComMensagem(Resources.Jogos.JogoSalvo, TipoMensagem.Sucesso);

                    }
                }

                return View(jogo);
            }
            catch (Exception exception)
            {
                LogBll.GravarErro(exception, User.Identity.Name);
                return RedirectToAction("Index").ComMensagem(Resources.Geral.ContateAdministrador, TipoMensagem.Erro);
            }
        }
    }
}