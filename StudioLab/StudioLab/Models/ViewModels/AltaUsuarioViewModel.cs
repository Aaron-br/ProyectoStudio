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
        [Display(Name ="Nombre:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Apellido 1:")]
        public string Apellido1 { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Apellido 2:")]
        public string Apellido2 { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Edad:")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Rol:")]
        public string Rol { get; set; }



    }
}