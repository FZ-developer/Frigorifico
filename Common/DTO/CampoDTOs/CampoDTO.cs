using Common.DTO.Frigorifico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DTO.CampoDTOs
{
    public class CampoDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int IdFrigorifico { get; set; } = 1;
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public int CantidadVacas { get; set; }
        public decimal DeudaAPagar { get; set; }
    }
}
