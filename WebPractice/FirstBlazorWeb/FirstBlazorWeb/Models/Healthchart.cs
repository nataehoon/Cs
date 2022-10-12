using System;
using System.Collections.Generic;

namespace FirstBlazorWeb.Models
{
    public partial class Healthchart
    {
        public int Heno { get; set; }
        public string Id { get; set; } = null!;
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? Fat { get; set; }
        public double? Muscle { get; set; }
        public string Jobtype { get; set; } = null!;
        public double? Totalcho { get; set; }
        public double? Hdl { get; set; }
        public double? Ldl { get; set; }
        public double? Bun { get; set; }
        public double? Crtn { get; set; }
        public string? Memo { get; set; }
        public string? Remark { get; set; }
        public double? Glufa { get; set; }
        public double? Gluhemo { get; set; }
        public DateTime? Regdate { get; set; }

        public virtual Member IdNavigation { get; set; } = null!;
    }
}
