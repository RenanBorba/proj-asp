using System;
using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Fornecedor: Codificação de Entidade na camada de Domínio(Regra de Negócio)
    public class Fornecedor //: Pessoa
    {
        public int IdFornecedor { get; set; }

        public string DescricaoFornecedor { get; set; }
        public string NomeResponsavel { get; set; }
        public string InscricaoEstadual { get; set; }

        //Pessoa
        public string TipoPessoa { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }


        //Endereço
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }


        //Telefone
        public string TipoTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public bool AcessoWpp { get; set; }

        public bool FornecedorAtivo { get; set; }


        public ICollection<Produto> Produtos { get; set; }
    }
}
