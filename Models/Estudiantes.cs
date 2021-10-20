using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UINProject.Models
{
    public class Estudiantes
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreEstudiante { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string CarnetEstudiante { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int EdadEstudiante { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int TelefonoEstudiante { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string CorreoEstudiante { get; set; }

        public int? IdDireccion { get; set; }
        public int? IdCohorte { get; set; }
        public int? IdEspecialidad { get; set; }

        [NotMapped]
        public string NombreDepartamento
        {
            get
            {
                using (Contexto contexto = new Contexto())
                {
                    return IdDireccion.HasValue ?
                        contexto.Departamentos.FirstOrDefault(x => x.IdDireccion == IdDireccion.Value).NombreDepartamento :
                        "- No Asignada! -";

                }
            }
        }

            [NotMapped]
        public string NombreCohorte
        {
            get
            {
                using (Contexto contexto = new Contexto())
                {
                    return IdCohorte.HasValue ?
                        contexto.Cohortes.FirstOrDefault(x => x.IdCohorte == IdCohorte.Value).NombreCohorte :
                        "- No Asignada! -";

                }
            }
        }

        [NotMapped]
        public string NombreEspecialidad
        {
            get
            {
                using (Contexto contexto = new Contexto())
                {
                    return IdEspecialidad.HasValue ?
                        contexto.Especialidades.FirstOrDefault(x => x.IdEspecialidad == IdEspecialidad.Value).NombreEspecialidad :
                        "- No Asignada! -";

                }
            }
        }
    }
}
    
