using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Producto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdFrigorifico { get; set; } = 1;

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int StockPorKg { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(9,2)")]
        public decimal PrecioPorKg { get; set; }



        
        public Frigorifico Frigorifico { get; set; }

        [JsonIgnore]
        public ICollection<DetalleFactura> DetallesFactura { get; set; } = new List<DetalleFactura>();
    }
}

