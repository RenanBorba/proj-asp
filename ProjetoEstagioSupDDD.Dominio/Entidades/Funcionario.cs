using System;

namespace ProjetoEstagioSupDDD.Dominio.Entidades
{
    //Funcionário: Codificação de Entidade na camada de Domínio (Regra de Negócio)
    public class Funcionario //: Pessoa
    {
        public int IdFuncionario { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public string TipoTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public bool AcessoWpp { get; set; }

        public bool Administrador { get; set; }
    }
}

