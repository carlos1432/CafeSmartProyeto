using System;
using System.Collections.Generic;

namespace WebCafeSmart.DataAccess;

public partial class CafeCaracteristica
{
    public int IdCafe { get; set; }

    public int IdCaracteristica { get; set; }

    public decimal? PrecioAjuste { get; set; }

    public virtual Cafe IdCafeNavigation { get; set; } = null!;

    public virtual Caracteristica IdCaracteristicaNavigation { get; set; } = null!;
}
