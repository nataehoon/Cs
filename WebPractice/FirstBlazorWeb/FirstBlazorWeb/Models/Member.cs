using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "아이디는 반드시 입력해 주세요.")]
        [StringLength(10, ErrorMessage = "아이디는 10자 이하로 입력하세요.")]
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "비밀번호는 반드시 입력해 주세요.")]
        [PasswordPropertyText(true)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).\\S{8,15}$", ErrorMessage ="비밀번호는 숫자/소문자/대문자/특수문자 조합으로 만들어 주세요.(단, 공백은 허용하지 않습니다.)")]
        public string Pw { get; set; } = null!;
        [Required(ErrorMessage = "비밀번호가 일치하지 않습니다.")]
        [PasswordPropertyText(true)]
        [Compare("Pw", ErrorMessage = "비밀번호가 일치하지 않습니다.")]
        public string Confirmpw { get; set; } = null!;
        [Required(ErrorMessage = "이름은 반드시 입력해 주세요.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "성별은 반드시 선택해 주세요.")]
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        [Required(ErrorMessage ="닉네임은 반드시 입력해 주세요.")]
        public string Nick { get; set; } = null!;
        [Required(ErrorMessage = "이메일은 반드시 입력해 주세요.")]
        [EmailAddress(ErrorMessage ="이메일 형식으로 작성해 주세요(ex. asdf@asdf.com")]
        public string Email { get; set; } = null!;
        public int? Hp { get; set; }
        public string? Pimage { get; set; }
        public string Resposibility { get; set; } = "미선택";
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
