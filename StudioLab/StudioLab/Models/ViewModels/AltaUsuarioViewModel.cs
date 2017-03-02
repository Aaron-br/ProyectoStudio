using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudioLab.Models.ViewModels
{
    public class AltaUsuarioViewModel
    {

        [Required(ErrorMessage = "This field is Required")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Apellido1 { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Apellido2 { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Rol { get; set; }



    }
}