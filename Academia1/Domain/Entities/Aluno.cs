using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }

        [ForeignKey("Cursos")]
        [Column(Order = 1)]
        public int IdCursos { get; set; }
        [NotMapped]
        public virtual Cursos? Cursos { get; set; }
    }
}
