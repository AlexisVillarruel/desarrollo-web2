using System;
using System.Collections.Generic;

namespace desarrollo_web2.Data;

public partial class Reservas
{
    public int ReservaId { get; set; }

    public int? UserId { get; set; }

    public int? ActividadId { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = null!;

    public virtual Actividades? Actividad { get; set; }

    public virtual Usuarios? User { get; set; }
}
