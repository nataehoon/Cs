using System;
using System.Collections.Generic;

namespace FirstBlazorWeb.Models
{
    public partial class Member
    {
        public Member()
        {
            Boards = new HashSet<Board>();
            Comments = new HashSet<Comment>();
            Exerciselogs = new HashSet<Exerciselog>();
            Healthcharts = new HashSet<Healthchart>();
        }

        public string Id { get; set; } = null!;
        public string Pw { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public string Nick { get; set; } = null!;
        public string? Email { get; set; }
        public int? Hp { get; set; }
        public string? Pimage { get; set; }
        public string Resposibility { get; set; } = null!;
        public string? Memo { get; set; }
        public string? Remark { get; set; }
        public string? Postop { get; set; }
        public string? Mehistory { get; set; }
        public string? Exhistory { get; set; }

        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Exerciselog> Exerciselogs { get; set; }
        public virtual ICollection<Healthchart> Healthcharts { get; set; }
    }
}
