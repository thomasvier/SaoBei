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
        public int ID { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("Adversario")]
        public int AdversarioID { get; set; }
    }
}