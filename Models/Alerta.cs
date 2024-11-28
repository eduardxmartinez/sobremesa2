using System;
using System.Collections.Generic;

namespace Sobremesa.Models;
public partial class Alerta
{
    public int AlertaId { get; set; }

    public int? InsumoId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Mensaje { get; set; }

    public virtual Insumo? Insumo { get; set; }
}
