using System;
using System.Collections.Generic;

namespace WebCafeSmart.DataAccess;

public partial class Usuario
{
    public int NroCedula { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
