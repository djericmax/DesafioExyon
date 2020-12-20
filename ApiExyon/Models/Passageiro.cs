using System;
using System.ComponentModel.DataAnnotations;

namespace ApiExyon.Models
{
    public class Passageiro
    {
        public Passageiro(){}
        
        public Passageiro(int id, string cPF, string nome, string sobrenome)
        {
            this.Id = id;
            this.CPF = cPF;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(14, ErrorMessage = "Campo deve conter 11 caracteres")]
        [MinLength(14, ErrorMessage = "Campo deve conter 11 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo pode ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo pode ter no máximo 50 caracteres")]
        public string Sobrenome { get; set; }
    }
}
