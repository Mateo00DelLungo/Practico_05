﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class TTurno
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime Hora { get; set; }

    public string Cliente { get; set; }

    internal virtual ICollection<TDetalle> TDetalles { get; set; } = new List<TDetalle>();
}