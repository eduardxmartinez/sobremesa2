using System;
using System.Collections.Generic;

namespace Sobremesa;

public partial class Venta
{
    public int VentaId { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetallesVenta> DetallesVenta { get; set; } = new List<DetallesVenta>();
}
