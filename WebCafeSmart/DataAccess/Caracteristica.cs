using System;
using System.Collections.Generic;

namespace WebCafeSmart.DataAccess;

public partial class Caracteristica
{
    public int IdCaracteristica { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<CafeCaracteristica> CafeCaracteristicas { get; set; } = new List<CafeCaracteristica>();

    public virtual ICollection<Cafe> Caves { get; set; } = new List<Cafe>();
}
