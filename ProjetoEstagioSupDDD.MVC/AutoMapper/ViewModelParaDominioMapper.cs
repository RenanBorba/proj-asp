using System;
using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;

namespace ProjetoEstagioSupDDD.MVC.AutoMapper
{
    public class ViewModelParaDominioMapper : Profile
    {
        public override string ProfileName
        {
            get { return "DominioParaViewModelMapper"; }
        }

        /*
        protected void Configure()
        {
            CreateMap<Pessoa, Models.PessoaViewModel>(); ..
        }
        */

        public ViewModelParaDominioMapper()
        {
            CreateMap<Cliente, Models.ClienteViewModel>();
            CreateMap<Fornecedor, Models.FornecedorViewModel>();
            CreateMap<Funcionario, Models.FuncionarioViewModel>();
            CreateMap<Servico, Models.ServicoViewModel>();
            CreateMap<Produto, Models.ProdutoViewModel>();
            CreateMap<TipoProduto, Models.TipoProdutoViewModel>();
            CreateMap<Marca, Models.MarcaViewModel>();
            CreateMap<Pedido, Models.PedidoViewModel>();
        }
    }
}