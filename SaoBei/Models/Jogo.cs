using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SaoBei.Models
{
    public class Jogo
    {
        public Jogo()
        {
            SituacaoJogo = SituacaoJogo.Confirmado;
            Data = DateTime.Today;            
        }

        public int ID { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Local { get; set; }

        [ForeignKey("Adversario")]
        public virtual int AdversarioID { get; set; }

        public virtual Adversario Adversario { get; set; }

        [ForeignKey("Calendario")]
        public virtual int CalendarioID { get; set; }

        public virtual Calendario Calendario { get; set; }

        [Display(Name = "Situação do jogo")]
        public SituacaoJogo SituacaoJogo { get; set; }

        [Display(Name = "Motivo do cancelamento")]
        public string MotivoCancelamento { get; set; }
    }
}