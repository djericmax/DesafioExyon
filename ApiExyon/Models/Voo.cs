using System;
using System.ComponentModel.DataAnnotations;

namespace ApiExyon.Models
{
    public class Voo
    {
        public Voo(){}

        public Voo(int id, string numdoVoo, string assento, DateTime dataPartida, DateTime horapartida, string valorPassagem, int ciaAereaId, int passageiroId)
        {
            this.Id = id;
            this.NumdoVoo = numdoVoo;
            this.Assento = assento;
            this.DataPartida = dataPartida;
            this.Horapartida = horapartida;
            this.ValorPassagem = valorPassagem;
            this.CiaAereaId = ciaAereaId;
            this.PassageiroId = passageiroId;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string NumdoVoo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Campo deve ter pelo menos 3 caracteres")]
        [MaxLength(8, ErrorMessage = "Campo deve ter no máximo 8 caracteres")]
        public string Assento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPartida { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Horapartida { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "Valor de passagem inválido")]
        public string ValorPassagem { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Companhia aérea inválida")]
        public int CiaAereaId { get; set; }

        public CiaAerea CiaAerea { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Passageiro inválido")]
        public int PassageiroId { get; set; }

        public Passageiro Passageiro { get; set; }
    }
}
