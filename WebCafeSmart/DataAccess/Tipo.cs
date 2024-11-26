using System;
using System.Collections.Generic;

namespace WebCafeSmart.DataAccess;

public partial class Tipo
{
    public int IdTipo { get; set; }

    public string NombreTipo { get; set; } = null!;

    public string? DescripcionTipo { get; set; }

    public string? Atributo { get; set; }

    public virtual ICollection<Cafe> Caves { get; set; } = new List<Cafe>();
}
