using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaoBei.Models
{
    public class Adversario
    {
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}