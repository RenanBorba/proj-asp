using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Tipo Produto: Codificação de Entidade na camada de Domínio(Regra de Negócio) ● Herança
    public class TipoProduto
    {
        public int IdTipoProduto { get; set; }
        public string DescricaoTipo { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
