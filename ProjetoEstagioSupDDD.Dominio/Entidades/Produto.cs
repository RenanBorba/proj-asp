using System;
using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Produto: Codificação de Entidade na camada de Domínio (Regra de Negócio)
    //Não necessário uso Data Annotations '[Key("Produto")]'
    //Não necessário uso Data Annotations '[ForeignKey("ProdutoTipo")]' 

    public class Produto
    {
        public int IdProduto { get; set; }

        //Relacionamento
        //public int IdTipoProduto { get; set; }
        public virtual TipoProduto TipoProdutos { get; set; }

        //public int IdMarca { get; set; }
        public virtual Marca Marcas { get; set; }

        //public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedores { get; set; }

        public string DescricaoProduto { get; set; }
        public double ValorCusto { get; set; }
        public double ValorVenda { get; set; }
        public DateTime DataCadastroProduto { get; set; }
        public DateTime DataValidade { get; set; }


        public ICollection<Pedido> Pedidos { get; set; }
        

    }
}

