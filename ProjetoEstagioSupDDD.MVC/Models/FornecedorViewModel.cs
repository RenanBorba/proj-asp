using ProjetoEstagioSupDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class FornecedorViewModel
    {
        [Key]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres!")]
        [DisplayName("Descrição Fornecedor")]
        public string DescricaoFornecedor { get; set; }

        [DisplayName("Nome Responsável")]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres!")]
        public string NomeResponsavel { get; set; }


        //Pessoa
        [DisplayName("Tipo")]
        [Required(ErrorMessage = "O campo Tipo é obrigatório!")]
        public string TipoPessoa { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(11, ErrorMessage = "Máximo de 11 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(11, ErrorMessage = "Mínimo de 11 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        //Aplicar mascara de entrada
        [DisplayFormat(DataFormatString = "{0:### . ### . ###-##}", ApplyFormatInEditMode = true)]
        public long CpfNumero { get { return Convert.ToInt64(Cpf); } }

        [DisplayName("Inscrição Estadual")]
        [MaxLength(13, ErrorMessage = "Máximo de 13 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(9, ErrorMessage = "Mínimo de 9 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        public string InscricaoEstadual { get; set; }

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

        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "O campo Data de Cadastro é obrigatório!")]
        [DataType(DataType.Date)]
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
        [MinLength(3, ErrorMessage = "Mínimo de 3 caractere! Insira 'Rua, Bairro, Número' ")]
        [DisplayName("Logradouro (Rua, Bairro, Número)")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório!")]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres!")]
        [DisplayName("Cidade, ESTADO")]
        public string Cidade { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres!")]
        [MinLength(1, ErrorMessage = "Mínimo de 1 caractere!")]
        public string Complemento { get; set; }


        //Telefone
        [Required(ErrorMessage = "O campo Tipo Telefone é obrigatório!")]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
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


        [DisplayName("Fornecedor Ativo")]
        public bool FornecedorAtivo { get; set; }


        public ICollection<Produto> Produtos { get; set; }
    }

}