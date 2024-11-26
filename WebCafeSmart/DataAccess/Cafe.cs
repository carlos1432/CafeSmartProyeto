using System;
using System.Collections.Generic;

namespace WebCafeSmart.DataAccess;

public partial class Cafe
{
    public int IdCafe { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int? IdTipo { get; set; }

    public int? IdCaracteristica { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CafeCaracteristica> CafeCaracteristicas { get; set; } = new List<CafeCaracteristica>();

    public virtual Caracteristica? IdCaracteristicaNavigation { get; set; }

    public virtual Tipo? IdTipoNavigation { get; set; }
}
