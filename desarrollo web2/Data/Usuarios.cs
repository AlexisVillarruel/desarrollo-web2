using System;
using System.Collections.Generic;

namespace desarrollo_web2.Data;

public partial class Usuarios
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Historial> Historial { get; set; } = new List<Historial>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual ICollection<Reseñas> Reseñas { get; set; } = new List<Reseñas>();
}
