using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DetalleFactura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdFacturaVenta { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int CantidadPorKg { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(9,2)")]
        public decimal PrecioTotalProducto { get; set; }



        
        public FacturaVenta FacturaVenta { get; set; }

        
        public Producto Producto { get; set; }
    }
}
