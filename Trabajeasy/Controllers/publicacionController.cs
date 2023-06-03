using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                                id = p.id_publicacion,
                                nombre_empresa = emp.nombre,
                                puesto = p.puesto,
                                info = p.informacion,
                                logo = emp.logo
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _trabajeasyContext.publicacion == null)
            {
                return NotFound();
            }

            var vacante =  await (from p in _trabajeasyContext.publicacion
                            join
                            e in _trabajeasyContext.empleador on p.id_empleador equals e.id_empleador
                            join emp in _trabajeasyContext.empresa on e.id_empresa equals emp.id_empresa
                            join depto in _trabajeasyContext.departamentos on p.id_departamento equals depto.id_depto
                            join tipo in _trabajeasyContext.tipoTrabajo on p.id_tipo equals tipo.id_tipo_trabajo
                            where p.id_publicacion == id
                            select new
                            {
                                id= p.id_publicacion,
                                nombre = emp.nombre,
                                puesto = p.puesto,
                                info = p.informacion,
                                logo = emp.logo,
                                salario = p.salario,
                                depto = depto.nombre_depto,
                                nivel = p.nivel,
                                tipo = tipo.area
                            }).FirstOrDefaultAsync(); ;
            if (vacante == null)
            {
                return NotFound();
            }
            ViewBag.Salario = vacante.salario;
            ViewBag.Nombre = vacante.nombre;
            ViewBag.Puesto = vacante.puesto;
            ViewBag.Depto = vacante.depto;
            ViewBag.Info = vacante.info;
            ViewBag.Nivel = vacante.nivel;
            ViewBag.Tipo = vacante.tipo;
            ViewBag.Logo = vacante.logo;
            return View(vacante);
        }
    }
}
