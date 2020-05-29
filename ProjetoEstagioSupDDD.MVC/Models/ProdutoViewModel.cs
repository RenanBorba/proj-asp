using ProjetoEstagioSupDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class ProdutoViewModel
    {
        [Key]
        public int IdProduto { get; set; }

        //Relacionamento
        [DisplayName("Tipo de Produto")]
        public int IdTipoProduto { get; set; }
        public TipoProduto TipoProdutos { get; set; }

        [DisplayName("Marca")]
        public int IdMarca { get; set; }
        public Marca Marcas { get; set; }

        [DisplayName("Fornecedor")]
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedores { get; set; }


        [Required(ErrorMessage = "O campo Descrição Produto é obrigatório!")]
        [MaxLength(75, ErrorMessage = "Máximo de 75 caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres!")]
        [DisplayName("Descrição do Produto")]
        public string DescricaoProduto { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [DisplayName("Valor de Custo")]
        public double ValorCusto { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [DisplayName("Valor de Repasse")]
        public double ValorVenda { get; set; }

        [DataType(DataType.Date)]        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastroProduto { get; set; }

        [DataType(DataType.Date)]        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Data de Validade")]
        public DateTime DataValidade { get; set; }


        public ICollection<Pedido> Pedidos { get; set; }
    }
}