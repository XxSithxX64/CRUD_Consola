using System.ComponentModel.DataAnnotations;

namespace CRUD_Consola.Core.Entities
{
    internal abstract class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; } 
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string DocIdentidad { get; set; } = string.Empty; // DNI, RUC, etc.
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
