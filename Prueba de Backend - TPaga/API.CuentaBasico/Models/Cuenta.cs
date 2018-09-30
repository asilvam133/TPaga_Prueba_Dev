using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.CuentaBasico.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        
        [Required]
        public string Numero { get; set; }
        
        public decimal Saldo { get; set; }

        // Navigation Property
        public Cliente Cliente { get; set; }
    }
}