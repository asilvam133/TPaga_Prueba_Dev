using System.ComponentModel.DataAnnotations;

namespace API.CuentaBasico.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        public string Telefono { get; set; }
        
        public string Direccion { get; set; }

        public string Ciudad { get; set; }
    }
}