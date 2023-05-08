using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class FacturaCompra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; }

        [Required]
        public int IdCampo { get; set; }
                
        [Required]
        public int IdFrigorifico { get; set; }
                
        [Required]
        public TipoDePago TipoDePago { get; set; }

        [Required]
        public int CantidadVacas { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(7,2)")]
        public decimal PrecioVaca { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(9,2)")]
        public decimal PrecioTotalCompra { get; set; }






        
        public Campo Campo { get; set; }

        public Frigorifico Frigorifico { get; set; }
    }
}
