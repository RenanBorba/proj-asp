using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class FuncionarioViewModel
    {
        [Key]
        public int IdFuncionario { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [MaxLength(40, ErrorMessage = "Máximo de 40 caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres!")]
        public string Nome { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo de 40 caracteres!")]
        [MinLength(15, ErrorMessage = "Mínimo de 15 caracteres!")]
        [EmailAddress(ErrorMessage = "Informe um E-Mail válido!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Login")]
        [Required(ErrorMessage = "O campo Login é obrigatório!")]
        [MaxLength(15, ErrorMessage = "Máximo de 10 caracteres!")]
        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres!")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo Senha é obrigatório!")]
        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres!")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres!")]
        public string Senha { get; set; }

        
        [Required(ErrorMessage = "O campo Tipo Telefone é obrigatório!")]
        [DisplayName("Tipo Telefone")]
        public string TipoTelefone { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(11, ErrorMessage = "Máximo de 11 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(10, ErrorMessage = "Mínimo de 10 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [DisplayFormat(DataFormatString = "{0:xxxx-xxxxx}")]
        [DisplayName("Número do Telefone (c/DDD)")]
        public string NumeroTelefone { get; set; }

        [DisplayName("Acesso Whatsapp")]
        public bool AcessoWpp { get; set; }


        [Required(ErrorMessage = "O campo Funcionário é obrigatório!")]
        public bool Administrador { get; set; }
    }
}