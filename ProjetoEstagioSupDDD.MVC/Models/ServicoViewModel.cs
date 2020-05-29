using ProjetoEstagioSupDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioSupDDD.MVC.Models
{
    public class ServicoViewModel
    {
        [Key]
        public int IdServico { get; set; }
        
        [Required(ErrorMessage = "O campo Descrição de Serviço é obrigatório!")]
        [MaxLength(75, ErrorMessage = "Máximo de 75 caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres!")]
        [DisplayName("Descrição de Serviço")]
        public string DescricaoServico { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres!")]
        [DisplayName("Observações do Serviço (Ex.: Utilização Produtos)")]
        public string ObservacaoServico { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [DisplayName("Valor Serviço")]
        public double ValorServico { get; set; }


        public ICollection<Pedido> Pedidos { get; set; }
    }
}