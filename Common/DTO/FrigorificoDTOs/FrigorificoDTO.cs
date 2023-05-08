using Common.DTO.CampoDTOs;
using Common.DTO.ClienteDTOs;
using Common.DTO.FacturaCompraDTOs;
using Common.DTO.FacturaVentaDTOs;
using Common.DTO.ProductoDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DTO.Frigorifico
{
    public class FrigorificoDTO
    {
        [JsonIgnore]
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        [JsonIgnore]
        public string CategoriaIVA { get; set; } = "Responsable Inscripto";
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }        
        public string Mail { get; set; }
        public int CantidadVacas { get; set; }
        public decimal Caja { get; set; }
        public decimal DeudasACobrar { get; set; }
    }
}
