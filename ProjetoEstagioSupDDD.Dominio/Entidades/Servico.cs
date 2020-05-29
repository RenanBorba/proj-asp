using System;
using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Serviço: Codificação de Entidade na camada de Domínio(Regra de Negócio)
    public class Servico
    {
        public int IdServico { get; set; }
        public string DescricaoServico { get; set; }
        public string ObservacaoServico { get; set; }
        public double ValorServico { get; set; }


        public ICollection<Pedido> Pedidos { get; set; }
    }
}
