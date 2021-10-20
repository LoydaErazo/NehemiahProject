using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UINProject.Models
{
    public class Especialidades
    {

        [Key]
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreEspecialidad { get; set; }

        public int IdEspecialidades { get; set; }

        [ForeignKey("IdEspecialidad")]
        public ICollection<Estudiantes> Estudiantes { get; set; }
    }
}