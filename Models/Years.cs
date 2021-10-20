using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UINProject.Models
{
    public class Years
    {
        [Key]
        public int IdYear { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreYear { get; set; }

        [ForeignKey("IdYear")]
        public ICollection<Cohortes> Cohortes { get; set; }

    }
}