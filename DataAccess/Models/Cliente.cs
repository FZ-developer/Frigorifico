using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Cliente
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int IdFrigorifico { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(9,2)")]
        public decimal SaldoACobrar { get; set; }



        public ICollection<FacturaVenta>? FacturasVenta { get; set; } = new List<FacturaVenta>();




        
        public Frigorifico Frigorifico { get; set; }
        
    }
}
