using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaoBei.Models
{
    public class MensalidadeIntegrante
    {
        public int ID { get; set; }

        public int Mes { get; set; }

        [ForeignKey("Calendario")]
        public int CalendarioID { get; set; }

        public Calendario Calendario { get; set; }

        [ForeignKey("Integrante")]
        public int IntegranteID { get; set; }

        public Integrante Integrante { get; set; }

        public DateTime? DataPagamento { get; set; }
    }
}