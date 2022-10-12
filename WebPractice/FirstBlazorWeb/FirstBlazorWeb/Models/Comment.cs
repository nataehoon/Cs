using System;
using System.Collections.Generic;

namespace FirstBlazorWeb.Models
{
    public partial class Comment
    {
        public int Cono { get; set; }
        public string? Comment1 { get; set; }
        public int Groupno { get; set; }
        public int Depthno { get; set; }
        public int Recommend { get; set; }
        public string Id { get; set; } = null!;
        public DateTime Regdate { get; set; }
        public string? Remark { get; set; }
        public int? Bono { get; set; }

        public virtual Board? BonoNavigation { get; set; }
        public virtual Member IdNavigation { get; set; } = null!;
    }
}
