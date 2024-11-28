using System;
using System.Collections.Generic;

namespace Sobremesa.Models;
public partial class Usuario
{
    public int UsuarioID { get; set; }

    public string? Nombre { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
