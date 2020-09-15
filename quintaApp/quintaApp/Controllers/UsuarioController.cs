using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quintaApp.Models;

namespace quintaApp.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost] //os dados só podem ser enviados pelo método POST (usado por segurança).
        public ActionResult Index(Usuario usuario) // mesmo nome, mas parametros diferentes. Recebendo um objeto.
        {
            //formas de validar

            if(string.IsNullOrEmpty(usuario.nomeUsu))
            {
                ModelState.AddModelError("nomeUsu", "O campo nome é obrigatório");
            }

            if(usuario.senhaUsu != usuario.confirmarUsu)
            {
                ModelState.AddModelError("", "As senhas são diferentes!!");
            }

            if (ModelState.IsValid) // se ela for válida...
            {
                return View("Resultado", usuario); // retorne uma View chamada Resultado
            }
            return View(usuario); // senão, redirecione
        }

        public ActionResult Resultado()
        {
            return View();
        }

        public ActionResult Validalogin(string loginUsu)
        {
            var dbExemplo = new Collection<string>
            {
                "Catraio",
                "Fedelho",
                "Infrante"
            };
            return Json(dbExemplo.All(a => a.ToLower() != loginUsu.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}

