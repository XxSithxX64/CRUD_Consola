using CRUD_Consola.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Consola.UI
{
    internal class ClienteConsoleUI
    {
        private readonly ClienteService clienteService;

        public ClienteConsoleUI(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== CRUD Clientes ===");
                Console.WriteLine("1. Crear Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Actualizar Cliente");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre: ");
                        var nombre = Console.ReadLine();
                        Console.Write("Email: ");
                        var email = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        var telefono = Console.ReadLine();
                        clienteService.CrearCliente(nombre, email, telefono);
                        break;

                    case "2":
                        foreach (var c in clienteService.ListarClientes())
                            Console.WriteLine($"{c.ClienteId} - {c.Nombre} ({c.Email})");
                        break;

                    case "3":
                        Console.Write("Id del Cliente: ");
                        int idUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Nuevo nombre: ");
                        var nuevoNombre = Console.ReadLine();
                        clienteService.ActualizarCliente(idUpdate, nuevoNombre);
                        break;

                    case "4":
                        Console.Write("Id del Cliente: ");
                        int idDelete = int.Parse(Console.ReadLine());
                        clienteService.EliminarCliente(idDelete);
                        break;

                    case "0":
                        salir = true;
                        break;
                }
            }
        }
    }
}
