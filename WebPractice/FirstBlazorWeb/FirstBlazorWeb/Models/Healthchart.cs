using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FirstBlazorWeb.Models
{
    public partial class Healthchart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Heno { get; set; }
        public string Id { get; set; } = null!;
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? Fat { get; set; }
        public double? Muscle { get; set; }
        [Required(ErrorMessage ="직업 유형을 선택 해 주세요.")]
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
        [Required(ErrorMessage ="측정 날짜를 입력해 주세요.")]
        public DateTime Regdate { get; set; }

        public virtual Member IdNavigation { get; set; } = null!;
    }
}
