using System;
using System.Collections.Generic;

namespace desarrollo_web2.Data;

public partial class Actividades
{
    public int ActividadId { get; set; }

    public int? EmpresaId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Duration { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public virtual Empresas? Empresa { get; set; }

    public virtual ICollection<Historial> Historial { get; set; } = new List<Historial>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual ICollection<Reseñas> Reseñas { get; set; } = new List<Reseñas>();
}
