using System;
using System.Collections.Generic;

namespace Sobremesa;

public partial class DetallesVenta
{
    public int DetalleId { get; set; }

    public int? VentaId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Venta? Venta { get; set; }
}
