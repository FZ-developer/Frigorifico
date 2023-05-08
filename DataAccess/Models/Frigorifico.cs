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
    public class Frigorifico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string RazonSocial { get; set; }

        [Required]
        public string CUIT { get; set; }

        [Required]
        public string CategoriaIVA { get; set; } = "Responsable Inscripto";

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public int CantidadVacas { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(9,2)")]
        public decimal Caja { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(9,2)")]
        public decimal DeudasACobrar { get; set; }

        [JsonIgnore]
        public ICollection<Producto>? Productos { get; set; } = new List<Producto>();



        [JsonIgnore]
        public ICollection<Campo>? Campos { get; set; } = new List<Campo>();
        [JsonIgnore]
        public ICollection<FacturaCompra>? FacturasCompra { get; set; } = new List<FacturaCompra>();



        [JsonIgnore]
        public ICollection<Cliente>? Clientes { get; set; } = new List<Cliente>();
        [JsonIgnore]
        public ICollection<FacturaVenta>? FacturasVenta { get; set; } = new List<FacturaVenta>();
        
    }
}
