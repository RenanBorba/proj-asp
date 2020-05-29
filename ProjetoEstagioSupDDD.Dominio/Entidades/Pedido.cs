using System;
using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Pedido: Codificação de Entidade na camada de Domínio(Regra de Negócio)
    public class Pedido
    {
        //protected class PedidoFuncionario : Funcionario{ };

        public int IdPedido { get; set; }

        //Relacionamento
        public int IdCliente { get; set; }
        public virtual Cliente Clientes { get; set; }

        public int IdServico { get; set; }
        public virtual Servico Servicos { get; set; }

        public int IdProduto { get; set; }
        public virtual Produto Produtos { get; set; }  

        public DateTime DataVenda { get; set; }
        public string Cliente { get; set; }

        public double TotalPedido { get; set; }

        public int QtdParcela { get; set; }
        public string DescricaoPagamento { get; set; }

        //Cheque
        public string NumeroCheque { get; set; }
        public string CpfCnpjCheque { get; set; }
        public string NomeEmitente { get; set; }
        public string ContaCheque { get; set; }
        public DateTime ValidadeCheque { get; set; }

        //Cartao
        public string NumeroCartao { get; set; }
        public string BancoCartao { get; set; }
        public string ContaCartao { get; set; }
        public string NomeImpresso { get; set; }
        public DateTime ValidadeCartao { get; set; }
        public bool CartaoAtivo { get; set; }
    }
}
