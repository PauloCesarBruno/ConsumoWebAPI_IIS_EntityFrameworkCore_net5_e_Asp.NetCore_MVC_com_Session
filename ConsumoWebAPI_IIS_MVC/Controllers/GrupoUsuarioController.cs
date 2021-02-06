using ConsumoWebAPI_IIS_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ConsumoWebAPI_IIS_MVC.Controllers
{
    public class GrupoUsuarioController : Controller
    {   
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Lista = new GrupoUsuario().RetornarListagem();
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(GrupoUsuario grupo)
        {
            if(ModelState.IsValid)
            {
                grupo.Inserir();
                CarregarDados();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }       
        
        [HttpGet]
        public IActionResult Filtro()
        {
            ViewBag.Lista = new GrupoUsuario().RetornarListagem();
            return View();
        }

        [HttpPost]
        public IActionResult Filtro(GrupoUsuario filtro)
        {
            try
            { 
            string grupoid = filtro.GruposId.ToString();
            ViewBag.Lista = new GrupoUsuario().RetornarListagemId(grupoid);
            return View();
            }
            catch(Exception)
            {
                return View();
            }
        }

        private void CarregarDados()
        {
            ViewBag.ListaGrupos = new GrupoUsuario().RetornarListaGrupo();
            ViewBag.ListaUsuarios = new GrupoUsuario().RetornarListaUsuario();
        }
    }          
}


