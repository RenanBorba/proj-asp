using System;
using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;

namespace ProjetoEstagioSupDDD.MVC.AutoMapper
{
    public class DominioParaViewModelMapper : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelParaDominioMapper"; }
        }

        /*
         * Versão antiga
        protected void Configure()
        {
            CreateMap<Models.PessoaViewModel, Pessoa >();
        }
        */

        //Nova
        public DominioParaViewModelMapper()
        {
            CreateMap<Models.ClienteViewModel, Cliente>();
            CreateMap<Models.FornecedorViewModel, Fornecedor>();
            CreateMap<Models.FuncionarioViewModel, Funcionario>();
            CreateMap<Models.ServicoViewModel, Servico>();
            CreateMap<Models.ProdutoViewModel, Produto>();
            CreateMap<Models.TipoProdutoViewModel, TipoProduto>();
            CreateMap<Models.MarcaViewModel, Marca>();
            CreateMap<Models.PedidoViewModel, Pedido>();
        }
    }
}