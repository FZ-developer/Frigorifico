using Common.DTO.CampoDTOs;
using Common.DTO.Frigorifico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DTO.FacturaCompraDTOs
{
    public class FacturaCompraDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdCampo { get; set; }
        [JsonIgnore]
        public int IdFrigorifico { get; set; } = 1;
        public TipoDePagoCompraDTO TipoDePago { get; set; }
        public int CantidadVacas { get; set; }
        public decimal PrecioVaca { get; set; }
        public decimal PrecioTotalCompra { get; set; }
    }

    public enum TipoDePagoCompraDTO
    {
        Contado = 1,
        CuentaCorriente
    }
}

