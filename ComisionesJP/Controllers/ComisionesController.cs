using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // <-- NUEVO: Nos permite usar SelectList
using Microsoft.EntityFrameworkCore;
using ComisionesJP.Models;

namespace ComisionesJP.Controllers
{
    public class ComisionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComisionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método auxiliar para no repetir código: Carga los vendedores de la BD
        private void CargarVendedoresDropdown(int? vendedorSeleccionado = null)
        {
            var vendedores = _context.Vendedor.ToList();
            // Creamos una lista para la vista: Value es el Id, Text es el Nombre
            ViewBag.Vendedores = new SelectList(vendedores, "Id", "Nombre", vendedorSeleccionado);
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Cuando la página carga por primera vez, mandamos la lista de vendedores
            CargarVendedoresDropdown();
            return View();
        }

        [HttpPost]
        public IActionResult Index(DateTime fechaInicio, DateTime fechaFin, int? vendedorId)
        {
            var reglas = _context.CalculadorComision.ToList();

            // 1. Empezamos la consulta (AsQueryable permite ir armando el filtro por partes)
            var query = _context.Venta.Include(v => v.Vendedor).AsQueryable();

            // 2. Filtro obligatorio: Rango de fechas
            query = query.Where(v => v.FechaVenta >= fechaInicio && v.FechaVenta <= fechaFin);

            // 3. Filtro opcional: Si el usuario seleccionó un vendedor específico
            if (vendedorId.HasValue && vendedorId.Value > 0)
            {
                query = query.Where(v => v.VendedorId == vendedorId.Value);
            }

            // 4. Agrupamos y sumamos
            var comisiones = query
                .GroupBy(v => v.Vendedor)
                .Select(g => new
                {
                    Vendedor = g.Key.Nombre,
                    TotalVentas = g.Sum(x => x.Monto)
                })
                .ToList();

            var resultados = new List<ResumenComisionViewModel>();

            foreach (var item in comisiones)
            {
                var reglaAplicable = reglas.FirstOrDefault(r => item.TotalVentas >= r.MontoMinimo && item.TotalVentas <= r.MontoMaximo);
                var porcentaje = reglaAplicable != null ? reglaAplicable.Porcentaje : 0;

                resultados.Add(new ResumenComisionViewModel
                {
                    NombreVendedor = item.Vendedor,
                    TotalVentas = item.TotalVentas,
                    PorcentajeAplicado = porcentaje * 100,
                    ComisionCalculada = item.TotalVentas * porcentaje
                });
            }

            // Guardamos las selecciones del usuario para que no se le borren de la pantalla
            ViewBag.FechaInicio = fechaInicio.ToString("yyyy-MM-dd");
            ViewBag.FechaFin = fechaFin.ToString("yyyy-MM-dd");
            CargarVendedoresDropdown(vendedorId); // Volvemos a cargar la lista, dejando marcado el que eligió

            return View(resultados);
        }
    }
}