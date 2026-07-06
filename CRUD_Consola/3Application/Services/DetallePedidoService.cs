using CRUD_Consola._1Core.IRepository;
using CRUD_Consola._1Core.IService;
using CRUD_Consola.Core.Entities;

namespace CRUD_Consola._3Application.Services
{
    public class DetallePedidoService : Service<DetallePedido>, IDetallePedidoService
    {
        private readonly IDetallePedidoRepository detallePedidoRepository;
        public DetallePedidoService(IDetallePedidoRepository detallePedidoRepository) : base(detallePedidoRepository)
        {
            this.detallePedidoRepository = detallePedidoRepository;
        }
        public IEnumerable<DetallePedido> ObtenerDetallePedidoDetallado()
        {
            return detallePedidoRepository.ListarDetallePedido();
        }
    }
}