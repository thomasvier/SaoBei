﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaoBei.Models;
using System.Data.Entity;

namespace SaoBei.Negocio
{
    public class MensalidadesBll
    {
        Contexto db;

        public MensalidadesBll()
        {
            db = new Contexto();
        }

        /// <summary>
        /// Retorna todas as mensalidades
        /// </summary>
        /// <returns></returns>
        public IQueryable<Mensalidades> RetornarMensalidades()
        {
            IQueryable<Mensalidades> mensalidades = db.Mensalidades;

            return mensalidades;
        }

        /// <summary>
        /// Retornar mensalidades do integrante
        /// </summary>
        /// <param name="integranteID"></param>
        /// <returns></returns>
        public IQueryable<Mensalidades> RetornarMensalidadesIntegrante(int integranteID)
        {
            IQueryable<Mensalidades> mensalidades = db.Mensalidades.Where(x => x.IntegrandeID == integranteID && x.Ativo == true);

            return mensalidades;
        }

        /// <summary>
        /// Retornar mensalidades do integrante 
        /// </summary>
        /// <param name="integranteID">Integrante</param>
        /// <param name="calendarioID">Calendario passado por parametro</param>
        /// <returns></returns>
        public IQueryable<Mensalidades> RetornarMensalidadesIntegranteCalendario(int integranteID, int calendarioID)
        {
            IQueryable<Mensalidades> mensalidades = db.Mensalidades.Where(x => x.IntegrandeID == integranteID && x.CalendarioID == calendarioID && x.Ativo == true);

            return mensalidades;
        }

        /// <summary>
        /// Insere uma nova mensalidade no banco
        /// </summary>
        /// <param name="mensalidades"></param>
        /// <returns></returns>
        public Mensalidades Criar(Mensalidades mensalidades)
        {
            db.Mensalidades.Add(mensalidades);
            db.SaveChanges();

            return mensalidades;
        }

        /// <summary>
        /// Atualiza uma mensalidade existente
        /// </summary>
        /// <param name="mensalidades"></param>
        /// <returns></returns>
        public Mensalidades Atualizar(Mensalidades mensalidades)
        {
            db.Entry(mensalidades).State = EntityState.Modified;
            db.SaveChanges();

            return mensalidades;
        }

        /// <summary>
        /// Verifica se existe mensalidades para o integrante no calendário recebido
        /// </summary>
        /// <param name="integranteID"></param>
        /// <param name="calendarioID"></param>
        /// <returns></returns>
        public bool VerificarExisteMensalidadesCalendarioIntegrante(int integranteID, int calendarioID)
        {
            if (RetornarMensalidadesIntegranteCalendario(integranteID, calendarioID).ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Criar mensalidades para todos os integrantes que ainda não possuem
        /// </summary>
        /// <param name="calendarioID"></param>
        public void CriarMensalidades(int calendarioID)
        {
            IQueryable<Integrante> integrantes = IntegranteBll.RetornarIntegrantesAtivos();
            MensalidadesBll mensalidadesBll = new MensalidadesBll();

            foreach (Integrante integrante in integrantes)
            {
                if (!mensalidadesBll.VerificarExisteMensalidadesCalendarioIntegrante(integrante.ID, calendarioID))
                {
                    Mensalidades mensalidades = new Mensalidades();

                    mensalidades.IntegrandeID = integrante.ID;
                    mensalidades.CalendarioID = calendarioID;

                    mensalidadesBll.Criar(mensalidades);
                }
            }
        }
    }
}