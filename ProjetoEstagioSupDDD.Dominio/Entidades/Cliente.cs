using System;
using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Cliente: Codificação de Entidade na camada de Domínio(Regra de Negócio)
    public class Cliente //: Pessoa
    {
        public int IdCliente { get; set; }
        public string TipoPessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        //Pessoa
        public string Nome { get; set; }
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

        public bool ClienteAtivo { get; set; }


        public ICollection<Pedido> Pedidos { get; set; }
    }
}
