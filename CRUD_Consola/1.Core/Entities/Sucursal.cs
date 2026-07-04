using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Consola.Core.Entities
{
    internal class Sucursal
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
