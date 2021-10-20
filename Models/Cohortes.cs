using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UINProject.Models
{
    public class Cohortes
    {
        [Key]
        public int IdCohorte { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreCohorte { get; set; }

        public int IdYear { get; set; }

        [ForeignKey("IdCohorte")]
        public ICollection<Estudiantes> Estudiantes { get; set; }

        [NotMapped]
        public string NombreYear
        {
            get
            {
                using (Contexto contexto = new Contexto())
                {
                    return contexto.Years.FirstOrDefault(x => x.IdYear == IdYear).NombreYear;

                }
            }
        }
    }
}