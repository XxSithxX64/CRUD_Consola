using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Consola.Core.Entities
{
    internal class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }

        public int SucursalId { get; set; }
        public Sucursal? Sucursal { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
