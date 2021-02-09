using ConsumoWebAPI_IIS_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ConsumoWebAPI_IIS_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            var url = "http://192.168.1.146:5800/api/Usuario";

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em Array de (Usuario)...
            Usuarios[] Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuarios[]>(res);

            return View(Data);
        }

        // Retirei o Details...
        //========================================================================

        /* GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            // Concatenar com Id de Grupo...
            var url = "http://192.168.1.146:5800/api/Usuario/" + id.ToString();

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em Array de (Usuario)...
            Usuarios Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuarios>(res);


            return View(Data);
        }   */

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios Data)
        {
            try
            {
                var wc = new WebClient();
                var url = "http://192.168.1.146:5800/api/Usuario";

                // Serializa em formato "Json" os dados de (Usuario)...
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(Data);

                // Configuração do WebClient para envio do Json
                wc.Headers.Add("Content-Type", "application/json");

                // Envio do Json ao WebService
                wc.UploadString(url, json);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            // Concatenar com Id de Grupo...
            var url = "http://192.168.1.146:5800/api/Usuario/" + id.ToString();

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em um Objeto de (Usuario)...
            Usuarios Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuarios>(res);

            // Passando o Grupo A View (Data)...
            return View(Data);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuarios Data)
        {
            try
            {
                var wc = new WebClient();
                // Concatenar com Id de Grupo...
                var url = "http://192.168.1.146:5800/api/Usuario/" + id.ToString();

                // Serializa em formato "Json" os dados de (Usuario)...
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(Data);

                // Configuração do WebClient para envio do Json
                wc.Headers.Add("Content-Type", "application/json");

                // Envio do Json ao WebService com o método PUT
                wc.UploadString(url, "PUT", json);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            // Concatenar com Id de Grupo...
            var url = "http://192.168.1.146:5800/api/Usuario/" + id.ToString();

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em um Objeto de (Usuario)...
            Usuarios Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuarios>(res);

            // Passando o Grupo A View (Data)...
            return View(Data);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var wc = new WebClient();
                // Concatenar com Id de Grupo...
                var url = "http://192.168.1.146:5800/api/Usuario/" + id.ToString();


                // Envio do Json ao WebService com o método DELETE
                wc.UploadString(url, "DELETE", "");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
