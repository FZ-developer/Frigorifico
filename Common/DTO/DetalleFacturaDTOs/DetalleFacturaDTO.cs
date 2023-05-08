using Common.DTO.FacturaVentaDTOs;
using Common.DTO.ProductoDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DTO.DetalleFacturaDTOs
{
    public class DetalleFacturaDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int IdFacturaVenta { get; set; }
        public int IdProducto { get; set; }
        public int CantidadPorKg { get; set; }
        public decimal PrecioTotalProducto { get; set; }



        
        [JsonIgnore]
        public ProductoDTO Producto { get; set; }
    }
}
