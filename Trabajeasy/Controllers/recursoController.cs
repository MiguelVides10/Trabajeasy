using Microsoft.AspNetCore.Mvc;
using Trabajeasy.Models;

namespace Trabajeasy.Controllers
{
    public class recursoController : Controller
    {
        private readonly trabajeasyContext _trabajeasyContext;

        public recursoController(trabajeasyContext trabajeasyContext)
        {
            _trabajeasyContext = trabajeasyContext;
        }

        public IActionResult Index()
        {

            var recursosEntrevistas =(from r in _trabajeasyContext.recurso 
                           where r.tipo=="Entrevista"
                           select 
                           new
                           {
                               titulo = r.titulo,
                               imagen = r.imagen,
                               info = r.informacion,
                               url = r.url
                           }).Take(3).ToList();
            ViewData["recursoEnt"] = recursosEntrevistas;

            var recursosVideos = (from r in _trabajeasyContext.recurso
                                       where r.tipo == "Video"
                                       select
                                       new
                                       {
                                           titulo = r.titulo,
                                           imagen = r.imagen,
                                           info = r.informacion,
                                           url = r.url
                                       }).Take(3).ToList();
            ViewData["recursoVid"] = recursosVideos;
            var recursosArt = (from r in _trabajeasyContext.recurso
                                  where r.tipo == "Articulo"
                                  select
                                  new
                                  {
                                      nombre = r.titulo,
                                      imagen = r.imagen,
                                      info = r.informacion,
                                      url = r.url
                                  }).Take(3).ToList();
            ViewData["recursoArt"] = recursosArt;

            return View();

        }
    }
}
