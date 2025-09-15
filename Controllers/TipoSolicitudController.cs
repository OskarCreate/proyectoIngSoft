using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace proyectoIngSoft.Controllers
{
    
    public class TipoSolicitudController : Controller
    {
        private readonly ILogger<TipoSolicitudController> _logger;

        public TipoSolicitudController(ILogger<TipoSolicitudController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}