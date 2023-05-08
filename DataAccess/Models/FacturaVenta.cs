using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class FacturaVenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaVenta { get; set; }

        [Required]
        public int IdFrigorifico { get; set; }

        [Required]
        public TipoDePago TipoDePago { get; set; }

        [Required]
        public string Vendedor { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(9,2)")]
        public decimal PrecioTotalVenta { get; set; }



        public ICollection<DetalleFactura>? DetallesFactura { get; set; } = new List<DetalleFactura>();




        public Cliente Cliente { get; set; }

        public Frigorifico Frigorifico { get; set; }
    }

    public enum TipoDePago
    {
        Contado = 1,
        CuentaCorriente
    }
}
