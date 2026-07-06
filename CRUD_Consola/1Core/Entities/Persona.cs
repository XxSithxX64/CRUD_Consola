using System.ComponentModel.DataAnnotations;

namespace CRUD_Consola.Core.Entities
{
    public abstract class Persona
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

        public override string ToString()
        {
            return $"[{PersonaId}] {Nombres} {ApellidoPat} {ApellidoMat} - " +
                   $"DNI: {DocIdentidad}, Nac: {FechaNacimiento:dd/MM/yyyy}, " +
                   $"Email: {Email}, Tel: {Telefono}, Dir: {Direccion}";
        }
    }
}
