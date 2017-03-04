using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioLab.Models.ViewModels
{
    public class UsuariosViewModel
    {

        //Definimos una lista de Usuarios de la BD
        public List <Usuarios> usuarios { get; set; }

        public int num_Paginas { get; set; }

    }
}