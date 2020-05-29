using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class TipoProdutoViewModel
    {
        [Key]
        public int IdTipoProduto { get; set; }
       
        [Required(ErrorMessage = "O campo Descrição de Tipo de Produto é obrigatório!")]
        [MaxLength(75, ErrorMessage = "Máximo de 75 caracteres!")]
        [MinLength(1, ErrorMessage = "Mínimo de 1 caracteres!")]
        [DisplayName("Tipo de Produto")]
        public string DescricaoTipo { get; set; }


        public ICollection<Produto> Produtos { get; set; }
    }
}