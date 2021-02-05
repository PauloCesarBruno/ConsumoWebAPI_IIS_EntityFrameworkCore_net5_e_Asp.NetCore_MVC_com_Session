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
    public class GrupoController : Controller
    {
        // GET: GrupoController
        public ActionResult Index()
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            var url = "http://192.168.1.146:5800/api/Grupo";

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em Array de (Grupo)...
            Grupo[] Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Grupo[]>(res);

            return View(Data);
        }

        // GET: GrupoController/Details/5
        public ActionResult Details(int id)
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            // Concatenar com Id de Grupo...
            var url = "http://192.168.1.146:5800/api/Grupo/" + id.ToString();

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em Array de (Grupo)...
            Grupo Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Grupo>(res);


            return View(Data);
        }

        // GET: GrupoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grupo Data)
        {
            try
            {
                var wc = new WebClient();
                var url = "http://192.168.1.146:5800/api/Grupo";

                // Serializa em formato "Json" os dados de (Grupo)...
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

        // GET: GrupoController/Edit/5
        public ActionResult Edit(int id)
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            // Concatenar com Id de Grupo...
            var url = "http://192.168.1.146:5800/api/Grupo/" + id.ToString();

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em um Objeto de (Grupo)...
            Grupo Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Grupo>(res);

            // Passando o Grupo A View (Data)...
            return View(Data);
        }

        // POST: GrupoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Grupo Data)
        {
            try
            {
                var wc = new WebClient();
                // Concatenar com Id de Grupo...
                var url = "http://192.168.1.146:5800/api/Grupo/" + id.ToString();

                // Serializa em formato "Json" os dados de (Grupo)...
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

        // GET: GrupoController/Delete/5
        public ActionResult Delete(int id)
        {
            var wc = new WebClient();

            // Obs.: a API do daURL abaixo esta rodando no meu IIS.Express...
            // Concatenar com Id de Grupo...
            var url = "http://192.168.1.146:5800/api/Grupo/" + id.ToString();

            // Chama WebService do tipo Rest
            var res = wc.DownloadString(url);

            // Deserializa o Json e converte em um Objeto de (Grupo)...
            Grupo Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Grupo>(res);

            // Passando o Grupo A View (Data)...
            return View(Data);
        }

        // POST: GrupoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var wc = new WebClient();
                // Concatenar com Id de Grupo...
                var url = "http://192.168.1.146:5800/api/Grupo/" + id.ToString();
                

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