using System;
using System.Collections.Generic;

namespace T_31JUL.Model;

public partial class Asistencia
{
    public int IdAsistencia { get; set; }

    public int? IdInscripcion { get; set; }

    public DateTime? FechaAsistencia { get; set; }

    public virtual Inscripciones? IdInscripcionNavigation { get; set; }
}
