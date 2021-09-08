using Conversao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Conversao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult converteDistancia(float numero, string medida)
        {
            RespostaViewModel resposta = new RespostaViewModel();
            resposta.Converter = numero;
            switch (medida)
            {
                case "cm":
                    resposta.Index = "cm";
                    resposta.Resultado = numero * 100;
                    break;
                case "mm":
                    resposta.Index = "mm";
                    resposta.Resultado = numero * 1000;
                    break;
                case "km":
                    resposta.Index = "km";
                    resposta.Resultado = numero / 1000;
                    break;
                case "pe":
                    resposta.Index = "pe";
                    resposta.Resultado = numero * 3.28084;
                    break;
                case "milha":
                    resposta.Index = "milha";
                    resposta.Resultado = numero * 0.000621371;
                    break;
                default:
                    return View("Index", -1);
            }
            return View("Index", resposta);
        }
    }
}
