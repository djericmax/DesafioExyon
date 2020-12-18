using System;
using System.ComponentModel.DataAnnotations;

namespace ApiExyon.Models
{
    public class CiaAerea
    {
        public CiaAerea(){}
        
        public CiaAerea(int id, string companhiaAerea, string aviao, string qtdeAssentos)
        {
            this.Id = id;
            this.CompanhiaAerea = companhiaAerea;
            this.Aviao = aviao;
            this.QtdeAssentos = qtdeAssentos;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo pode ter o máximo de 50 caracteres")]
        public string CompanhiaAerea { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Número do Avião inválido")]
        public string Aviao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade de Assentos inválida")]
        public string QtdeAssentos { get; set; }
    }
}
