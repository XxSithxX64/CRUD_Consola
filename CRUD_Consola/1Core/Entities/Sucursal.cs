namespace CRUD_Consola.Core.Entities
{
    public class Sucursal
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

        public override string ToString()
        {
            return $"{SucursalId}, {Nombre}, {Direccion}";
        }
    }
}
