using System.Web.Mvc;
using StudioLab.Models.ViewModels;
using StudioLab.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudioLab.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios

        //Objeto que nos pertmite acceder a la BD mapaeada.
        private StudioLabDBEntities myDB;
        private Usuarios usuBorrado;


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

        public ActionResult AltaUsuario()
        {

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