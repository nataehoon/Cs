using System;
using System.Collections.Generic;

namespace FirstBlazorWeb.Models
{
    public partial class Exercise
    {
        [Required(ErrorMessage ="운동 이름을 작성해 주세요.")]
        public string Exname { get; set; } = null!;
        [Required(ErrorMessage = "운동 타입을 선택해 주세요.")]
        public string Extype { get; set; } = null!;
        public string? Equipment { get; set; }
    }
}
