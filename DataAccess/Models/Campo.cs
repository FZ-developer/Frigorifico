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
    public class Campo
    {
        [Key]
        [Required]
        public int Id { get; set; }

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
        public int CantidadVacas { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(11,2)")]
        public decimal DeudaAPagar { get; set; }




        [JsonIgnore]
        public Frigorifico Frigorifico { get; set; }

        [JsonIgnore]
        public ICollection<FacturaCompra> FacturasCompra { get; set; }
    }
}
