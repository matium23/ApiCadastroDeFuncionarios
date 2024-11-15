using ControleDeFuncionarios.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeFuncionarios.Models
{
    
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }


        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public TurnoEnum Turno { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo {  get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAltercao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
