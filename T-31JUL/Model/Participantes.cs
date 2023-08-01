using System;
using System.Collections.Generic;

namespace T_31JUL.Model;

public partial class Participantes
{
    public int IdParticipante { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Inscripciones> Inscripciones { get; set; } = new List<Inscripciones>();
}
