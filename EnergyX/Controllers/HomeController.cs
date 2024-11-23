using EnergyX.Models;
using EnergyX.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnergyX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOperadoresService _operadoresService;
        private readonly IRelatoriosTurnoService _relatoriosTurnoService;
        private readonly IReatoresService _reatoresService;

        public HomeController(ILogger<HomeController> logger, IOperadoresService operadoresService, IRelatoriosTurnoService relatoriosTurnoService, IReatoresService reatoresService)
        {
            _logger = logger;
            _operadoresService = operadoresService;
            _relatoriosTurnoService = relatoriosTurnoService;
            _reatoresService = reatoresService;
        }


        public IActionResult Index()
        {
            int? operadorId = HttpContext.Session.GetInt32("OperadorId");
            if (operadorId.HasValue)
            {
                return View();
            }
            else
            {
                TempData["ErrorMessage"] = "Sessão Expirada! Realize o login para acessar o sistema.";
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            var operador = await _operadoresService.GetOperadorByLorAsync("LOR3");

            int? operadorId = HttpContext.Session.GetInt32("OperadorId");
            if (operadorId.HasValue)
            {
                return View(operador);
            }
            else
            {
                TempData["ErrorMessage"] = "Sessão Expirada! Realize o login para acessar o sistema.";
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RelatoriosTurno([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var relatorios = await _relatoriosTurnoService.GetAllRelatoriosTurnoAsync(pageNumber, pageSize); // Busca todos os relatorios

            // Busca todos os reatores e popula o ViewBag
            var reatores = await _reatoresService.GetAllReatoresAsync();
            if (reatores != null)
            {
                ViewBag.Reatores = reatores.Select(r => new SelectListItem
                {
                    Value = r.ReatorId.ToString(),
                    Text = r.NomeReator
                }).ToList();
            }
            else
            {
                ViewBag.Reatores = new List<SelectListItem>(); // Garante que não será nulo
            }

            int? operadorId = HttpContext.Session.GetInt32("OperadorId");
            if (operadorId.HasValue)
            {
                return View(relatorios);
            }
            else
            {
                TempData["ErrorMessage"] = "Sessão Expirada! Realize o login para acessar o sistema.";
                return RedirectToAction("Index", "Login");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
