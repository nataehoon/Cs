using System;
using System.Collections.Generic;

namespace FirstBlazorWeb.Models
{
    public partial class Board
    {
        public Board()
        {
            Comments = new HashSet<Comment>();
        }

        public int Bono { get; set; }
        public string Id { get; set; } = null!;
        public string Boardtype { get; set; } = null!;
        public DateTime Regdate { get; set; }
        public int Readhit { get; set; }
        public int Recommend { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? Comment { get; set; }
        public string? Image { get; set; }
        public string? Attachfile { get; set; }
        public string? Remark { get; set; }

        public virtual Member IdNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
