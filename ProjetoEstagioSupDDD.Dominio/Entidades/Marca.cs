using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Marca: Codificação de Entidade na camada de Domínio(Regra de Negócio) ● Herança
    public class Marca
    {
        public int IdMarca { get; set; }
        public string DescricaoMarca { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
