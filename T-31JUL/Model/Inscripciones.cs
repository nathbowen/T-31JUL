using System;
using System.Collections.Generic;

namespace T_31JUL.Model;

public partial class Inscripciones
{
    public int IdInscripcion { get; set; }

    public int? IdParticipante { get; set; }

    public int? IdTaller { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual Participantes? IdParticipanteNavigation { get; set; }

    public virtual Talleres? IdTallerNavigation { get; set; }
}
