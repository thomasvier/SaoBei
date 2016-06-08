using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaoBei.Models
{
    public class Mensalidades
    {
        public Mensalidades()
        {
            Ativo = true;
        }

        public int ID { get; set; }

        public bool Janeiro { get; set; }

        public bool Fevereiro { get; set; }

        [Display(Name = "Março")]
        public bool Marco { get; set; }

        public bool Abril { get; set; }

        public bool Maio { get; set; }

        public bool Junho { get; set; }

        public bool Julho { get; set; }

        public bool Agosto { get; set; }

        public bool Setembro { get; set; }

        public bool Outubro { get; set; }

        public bool Novembro { get; set; }

        public bool Dezembro { get; set; }

        public bool Anuidade { get; set; }

        [ForeignKey("Calendario")]
        public virtual int CalendarioID { get; set; }

        public virtual Calendario Calendario { get; set; }

        [ForeignKey("Integrante")]
        public virtual int IntegrandeID { get; set; }

        public virtual Integrante Integrante { get; set; }

        public bool Ativo { get; set; }
    }
}