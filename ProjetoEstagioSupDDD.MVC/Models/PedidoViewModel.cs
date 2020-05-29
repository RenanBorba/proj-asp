using ProjetoEstagioSupDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class PedidoViewModel
    {
        [Key]
        public int IdPedido { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data Pedido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataCadastro { get; set; }

        //Relacionamento
        [DisplayName("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Clientes { get; set; }

        [DisplayName("Serviço")]
        public int IdServico { get; set; }
        public virtual Servico Servicos { get; set; }

        [DisplayName("Produto")]
        public int IdProduto { get; set; }
        public virtual Produto Produtos { get; set; }

        [DisplayName("Cliente não cadastrado")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres!")]
        public string ClienteNaoCadastrado { get; set; }       

        [DisplayName("Quantidade Parcelas")]
        [Required(ErrorMessage = "O campo Quantidade de Parcelas é obrigatório!")]
        public int QtdParcela { get; set; }
  
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [DisplayName("Total Pedido")]
        public double TotalPedido { get; set; }

        [DisplayName("Descrição Pagamento")]
        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres!")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres!")]
        public string Descricao { get; set; }


        //Cheque
        [DisplayName("Número Cheque")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(19, ErrorMessage = "Mínimo de 19 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        public string NumeroCheque { get; set; }

        [DisplayName("Nome Emitente")]
        [MaxLength(35, ErrorMessage = "Máximo de 35 caracteres!")]
        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres!")]
        public string NomeEmitente { get; set; }

        [DisplayName("CPF ou CNPJ Emitente")]
        [MaxLength(14, ErrorMessage = "Máximo de 14 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(11, ErrorMessage = "Mínimo de 11 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        public string CpfCnpjCheque { get; set; }

        [DisplayName("Conta (c/Banco)")]
        [MaxLength(40, ErrorMessage = "Máximo de 40 caracteres!")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres!")]
        public string ContaCheque { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Validade Cheque")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ValidadeCheque { get; set; }


        //Cartao
        [DisplayName("Número Cartão (c/Cód segurança)")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        [MinLength(19, ErrorMessage = "Mínimo de 19 caracteres! Insira apenas números, sem pontos ou vírgulas!")]
        public string NumeroCartao { get; set; }

        [DisplayName("Nome Impresso")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres!")]
        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres!")]
        public string NomeImpresso { get; set; }     

        [DisplayName("Conta (c/Banco)")]
        [MaxLength(40, ErrorMessage = "Máximo de 40 caracteres!")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres!")]
        public string ContaCartao { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Validade Cartão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM}")]
        public DateTime ValidadeCartao { get; set; }

        [DisplayName("Cartão Ativo")]
        public bool CartaoAtivo { get; set; }
    }
}
