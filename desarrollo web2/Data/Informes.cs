using System;
using System.Collections.Generic;

namespace desarrollo_web2.Data;

public partial class Informes
{
    public int InformeId { get; set; }

    public string Type { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Date { get; set; }
}
