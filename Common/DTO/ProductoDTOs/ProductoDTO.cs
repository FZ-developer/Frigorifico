using Common.DTO.DetalleFacturaDTOs;
using Common.DTO.Frigorifico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DTO.ProductoDTOs
{
    public class ProductoDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int IdFrigorifico { get; set; } = 1;
        public string Nombre { get; set; }
        public int StockPorKg { get; set; }
        public decimal PrecioPorKg { get; set; }

    }
}
