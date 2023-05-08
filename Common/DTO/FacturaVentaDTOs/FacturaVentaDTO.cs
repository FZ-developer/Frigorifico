using Common.DTO.ClienteDTOs;
using Common.DTO.DetalleFacturaDTOs;
using Common.DTO.Frigorifico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DTO.FacturaVentaDTOs
{
    public class FacturaVentaDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        [JsonIgnore]
        public int IdFrigorifico { get; set; } = 1;
        public TipoDePagoDTO TipoDePago { get; set; }
        public string Vendedor { get; set; }
        public int IdCliente { get; set; }
        public decimal PrecioTotalVenta { get; set; }



        public ICollection<DetalleFacturaDTO>? DetallesFactura { get; set; }
    }

    public enum TipoDePagoDTO
    {
        Contado = 1,
        CuentaCorriente
    }

}
