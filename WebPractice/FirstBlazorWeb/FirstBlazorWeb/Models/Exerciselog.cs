using System;
using System.Collections.Generic;

namespace FirstBlazorWeb.Models
{
    public partial class Exerciselog
    {
        public int Exno { get; set; }
        public string Id { get; set; } = null!;
        public DateTime Exdate { get; set; }
        public string? Exlog { get; set; }
        public string? Memo { get; set; }
        public string Exname { get; set; } = null!;
        public string? Exrep { get; set; }
        public string? Exset { get; set; }
        public string? Exinten { get; set; }
        public int? Extime { get; set; }
        public string? Experiod { get; set; }
        public string? Eximage { get; set; }
        public string? Remark { get; set; }
        public string Extype { get; set; } = null!;

        public virtual Member IdNavigation { get; set; } = null!;
    }
}
