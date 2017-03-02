using System.Web.Mvc;
using StudioLab.Models.ViewModels;
using StudioLab.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace StudioLab.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios

        //Objeto que nos pertmite acceder a la BD mapaeada.
        private StudioLabDBEntities myDB;
        private Usuarios usuBorrado;
        private Usuarios usuAlta;


        public ActionResult Listado()
        {

            //Definimos el viewModel creado para los usuarios
            //Y lo rellenamos de datos de la BD.
            UsuariosViewModel vm;
            vm = new UsuariosViewModel();

            myDB = new StudioLabDBEntities();

            //Asignamos al viewModel la lista de usuario proveniente de la BD
            vm.usuarios = myDB.Usuarios.ToList();


            return View(vm);
        }
        [HttpGet] //Este es el valor por defecto del método
        public ActionResult AltaUsuario()
        {

            return View();

        }

        [HttpPost]
        public ActionResult AltaUsuario(AltaUsuarioViewModel model)
        {

            myDB = new StudioLabDBEntities();
            usuAlta = new Usuarios();

            //Esto comprueba si son correctos los datos del formulario
            if (ModelState.IsValid) {

                //Creamos el usuario con los datos recibidos
                usuAlta.nombre = model.Nombre;
                usuAlta.apellido1 = model.Apellido1;
                usuAlta.apellido2 = model.Apellido2;
                usuAlta.edad = Int32.Parse(model.Edad);
                usuAlta.usuarioRol = Int32.Parse(model.Rol);

                //Añadimos a la BD
                myDB.Usuarios.Add(usuAlta);
                myDB.SaveChanges();

                return RedirectToAction("Listado");
            }
          

            return View();
         

        }



        public ActionResult BorradoUsuario(int id)
        {

            myDB = new StudioLabDBEntities();

            //Recuperamos de la base de datos el usuario que queremos borrar
            usuBorrado = myDB.Usuarios.Where(u => u.idUsuario == id).FirstOrDefault();

            //Borramos de la base de datos
            myDB.Usuarios.Remove(usuBorrado);

            //Guardamos los cambios
            myDB.SaveChanges();


            return RedirectToAction("Listado");

        }



    }
}