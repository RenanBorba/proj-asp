using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class MarcaViewModel
    {
        [Key]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "O campo Descrição de Marca é obrigatório!")]
        [MaxLength(75, ErrorMessage = "Máximo de 75 caracteres!")]
        [MinLength(1, ErrorMessage = "Mínimo de 1 caracteres!")]
        [DisplayName("Descrição Marca")]
        public string DescricaoMarca { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}