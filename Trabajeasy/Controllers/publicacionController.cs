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


            var numEmpresas = (from e in _trabajeasyContext.empresa
                               select e).ToList().Count;
            ViewData["numEmpresas"] = numEmpresas;

            var numPublicaciones = (from p in _trabajeasyContext.publicacion
                               select p).ToList().Count;
            ViewData["numPublicaciones"] = numPublicaciones;

            var numUsuarios = (from u in _trabajeasyContext.usuario
                                    select u).ToList().Count;
            ViewData["numUsuarios"] = numUsuarios;

            var numRecursos = (from r in _trabajeasyContext.recurso
                               select r).ToList().Count;
            ViewData["numRecursos"] = numRecursos;

            var recursos = (from r in _trabajeasyContext.recurso
                            select r).ToList();
            ViewData["recursos"] = recursos;

            return View();
        }
    }
}
