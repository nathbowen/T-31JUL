using System;
using System.Collections.Generic;

namespace T_31JUL.Model;

public partial class Talleres
{
    public int IdTaller { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public int? DuracionHoras { get; set; }

    public int? CupoMaximo { get; set; }

    public virtual ICollection<Inscripciones> Inscripciones { get; set; } = new List<Inscripciones>();
}
