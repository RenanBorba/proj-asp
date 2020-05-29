using ProjetoEstagioSupDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class ClienteViewModel
    {
        [Key]
        public int IdCliente { get; set; }

        /*
        [ForeignKey("PessoaFK")]
        public int IdPessoaFK { get; set; }
        */

        
        [Required(ErrorMessage = "O campo Tipo Pessoa é obrigatório!")]
        [DisplayName("Tipo Pessoa")]
        public string TipoPessoa { get; set; }

        [DataType(DataType.Date)]      
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }


        //Pessoa
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres!")]
        public string Nome { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(11, ErrorMessage = "Máximo de 11 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(11, ErrorMessage = "Mínimo de 11 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [DisplayFormat(DataFormatString = "{0:### . ### . ###-##}", ApplyFormatInEditMode = true)] //Aplicar mascara
        public long CpfNumero { get { return Convert.ToInt64(Cpf); } }

        [DataType(DataType.Text)]
        [MaxLength(14, ErrorMessage = "Máximo de 14 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(14, ErrorMessage = "Mínimo de 14 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [DisplayName("CNPJ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:xx.xxx.xxx/xxxx-xx}")]
        public string Cnpj { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo de 40 caracteres!")]
        [MinLength(15, ErrorMessage = "Mínimo de 15 caracteres!")]
        [EmailAddress(ErrorMessage = "Informe um E-Mail válido!")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), DateTime.Now.Date, "", ErrorMessage = "Date must be after or equal to current date")]
        [DisplayName("Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataCadastro { get; set; }


        //Endereço
        [DataType(DataType.Text)]
        [MaxLength(8, ErrorMessage = "Máximo de 8 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(8, ErrorMessage = "Mínimo de 8 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [DisplayFormat(DataFormatString = "{0:xxxxx-xxx}")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório! Insira 'Rua, Bairro, Número' ")]
        [MaxLength(70, ErrorMessage = "Máximo de 70 caracteres! Insira 'Rua, Bairro, Número' ")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres! Insira 'Rua, Bairro, Número' ")]
        [DisplayName("Logradouro (Rua, Bairro, Número)")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório! Lembre-se do Estado!")]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres! Lembre-se do Estado!")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres! Lembre-se do Estado!")]
        [DisplayName("Cidade, ESTADO")]
        public string Cidade { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres!")]
        [MinLength(1, ErrorMessage = "Mínimo de 1 caracteres!")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }


        //Telefone
        [Required(ErrorMessage = "O campo Tipo Telefone é obrigatório!")]
        [DisplayName("Tipo Telefone")]
        public string TipoTelefone { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(11, ErrorMessage = "Máximo de 11 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(10, ErrorMessage = "Mínimo de 10 caracteres!  Insira apenas números, sem pontos ou vírgulas!")]
        [DisplayFormat(DataFormatString = "{0:xxxx-xxxxx}")]
        [DisplayName("Número do Telefone (c/DDD)")]
        public string NumeroTelefone { get; set; }

        [DisplayName("Acesso Whatsapp")]
        public bool AcessoWpp { get; set; }


        [DisplayName("Cliente Ativo")]
        public bool ClienteAtivo { get; set; }


        public ICollection<Pedido> Pedidos { get; set; }
    }
}