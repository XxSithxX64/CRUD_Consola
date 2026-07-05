using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services
{
    internal class PedidoService : Service<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository) : base(pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }
        public IEnumerable<Pedido> ObtenerPedidosDetallados()
        {
            return pedidoRepository.ListarConRelaciones();
        }
    }
}
