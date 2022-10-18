using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBlazorWeb.Models
{
    public partial class Exerciselog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Exno { get; set; }
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "운동 날짜를 입력해 주세요.")]
        public DateTime Exdate { get; set; }
        public string? Exlog { get; set; }
        public string? Memo { get; set; }
        [Required(ErrorMessage = "운동 이름을 선택해 주세요.")]
        public string Exname { get; set; } = null!;
        public string? Exrep { get; set; }
        public string? Exset { get; set; }
        public string? Exinten { get; set; }
        public int? Extime { get; set; }
        public string? Experiod { get; set; }
        public string? Eximage { get; set; }
        public string? Remark { get; set; }
        [Required(ErrorMessage = "운동 타입을 선택해 주세요.")]
        public string Extype { get; set; } = null!;

        public virtual Member IdNavigation { get; set; } = null!;
    }
}
