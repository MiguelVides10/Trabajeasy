using Microsoft.AspNetCore.Mvc;
using Trabajeasy.Models;

namespace Trabajeasy.Controllers
{
    public class publicacionController : Controller
    {

        private readonly trabajeasyContext _trabajeasyContext;

        public publicacionController(trabajeasyContext trabajeasyContext)
        {
            _trabajeasyContext = trabajeasyContext;
        }

        public IActionResult Index()
        {
            var vacantes = (from p in _trabajeasyContext.publicacion join
                            e in _trabajeasyContext.empleador on p.id_empleador equals e.id_empleador
                            join emp in _trabajeasyContext.empresa on e.id_empresa equals emp.id_empresa
                            select new
                            {
                                nombre_empresa= emp.nombre,
                                puesto = p.puesto,
                                info = p.informacion
                            }).ToList();
            ViewData["datos"] = vacantes;
            return View();
        }
    }
}
