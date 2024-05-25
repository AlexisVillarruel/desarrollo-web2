using System;
using System.Collections.Generic;

namespace desarrollo_web2.Data;

public partial class Empresas
{
    public int EmpresaId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Actividades> Actividades { get; set; } = new List<Actividades>();
}
