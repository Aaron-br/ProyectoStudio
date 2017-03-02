using System.Web.Mvc;
using StudioLab.Models.ViewModels;
using StudioLab.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;

namespace StudioLab.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios

        //Objeto que nos pertmite acceder a la BD mapaeada.
        private StudioLabDBEntities myDB;
        private Usuarios usuBorrado;
        private Usuarios usuAlta;
        private Usuarios usuEditar;

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

        [HttpGet]
        public ActionResult EditaUsuario(int id)
        {

            myDB = new StudioLabDBEntities();
            usuEditar = new Usuarios();

            EditaUsuarioViewModel usu = new EditaUsuarioViewModel();

            //Recuperamos de la BD el usuario que queremos editar
            usuEditar = myDB.Usuarios.Where(u => u.idUsuario == id).FirstOrDefault();

            usu.Nombre = usuEditar.nombre.TrimEnd();
            usu.Apellido1 = usuEditar.apellido1.TrimEnd();
            usu.Apellido2 = usuEditar.apellido2.TrimEnd();
            usu.Edad = usuEditar.edad.ToString();
            usu.Rol = usuEditar.usuarioRol.ToString();
            usu.IdUsuario = id;

            return View(usu);

        }



        [HttpPost]
        public ActionResult EditaUsuario(EditaUsuarioViewModel model)
        {

            myDB = new StudioLabDBEntities();
            usuEditar = new Usuarios();

            //Esto comprueba si son correctos los datos del formulario
            if (ModelState.IsValid)
            {

                usuEditar.nombre = model.Nombre;
                usuEditar.apellido1 = model.Apellido1;
                usuEditar.apellido2 = model.Apellido2;
                usuEditar.edad = Int32.Parse(model.Edad);
                usuEditar.usuarioRol = Int32.Parse(model.Rol);
                usuEditar.idUsuario = model.IdUsuario;

                myDB.Entry(usuEditar).State = EntityState.Modified;
                myDB.SaveChanges();


                return RedirectToAction("Listado");
            }


            return View();

        }


    }
}