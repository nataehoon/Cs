using System;
using System.Collections.Generic;

namespace FirstBlazorWeb.Models
{
    public partial class Exercise
    {
        public string Exname { get; set; } = null!;
        public string Extype { get; set; } = null!;
        public string? Equipment { get; set; }
    }
}
