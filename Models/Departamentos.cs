using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UINProject.Models
{
    public class Departamentos
    {
        [Key]
        public int IdDireccion { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreDepartamento { get; set; }

        [ForeignKey("IdDireccion")]
        public ICollection<Estudiantes> Estudiantes { get; set; }
    }
}