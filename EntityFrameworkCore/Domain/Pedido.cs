using EntityFrameworkCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime FinalizadoEm { get; set; }
        public TipoFreteEnum TipoFrete { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public string Observacao { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
    }
}
