using ControleDeFuncionarios.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeFuncionarios.Models
{
    [Table("Funcionarios")]
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do funcionario deve ser informado")]
        [StringLength(100, MinimumLength =10,ErrorMessage ="o nome deve ter entre 10 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sobrenome do funcionario deve ser informado")]
        [StringLength(100, MinimumLength =10,ErrorMessage ="O sobrenome do funcionario deve ter entre 10 e 100 caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage ="Informar o turno do funcionario")]
        public TurnoEnum Turno { get; set; }

        [Required(ErrorMessage ="Informar o departamento do funcionario")]
        public DepartamentoEnum Departamento { get; set; }

        public bool Ativo {  get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAltercao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
