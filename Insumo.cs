using System;
using System.Collections.Generic;

namespace Sobremesa;

public partial class Insumo
{
    public int InsumoId { get; set; }

    public string? Nombre { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual ICollection<Alerta> Alerta { get; set; } = new List<Alerta>();
}
