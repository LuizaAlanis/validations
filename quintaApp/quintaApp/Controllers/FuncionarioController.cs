using quintaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quintaApp.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            Funcionario func = new Funcionario
            {
                idFun = 1,
                nomeFun = "bronquinho",
                funcaoFun = "fulião"
            };
            return View(func);
        }

        [HttpPost]
        public ActionResult Listar(Funcionario funcionario)
        {
            return View(funcionario);
        }
    }
}


