using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Data;
using TecnoGasHogar.Models;

namespace TecnoGasHogar.Controllers;

public class SolicitudController : Controller
{
    private readonly ApplicationDbContext _context;

    public SolicitudController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Solicitud/Registrar
    [HttpGet]
    public IActionResult Registrar()
    {
        return View();
    }

    // POST: Solicitud/Registrar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registrar(SolicitudServicio solicitud)
    {
        if (ModelState.IsValid)
        {
            solicitud.FechaRegistro = DateTime.Now;
            _context.SolicitudesServicio.Add(solicitud);
            await _context.SaveChangesAsync();

            TempData["MensajeExito"] = $"¡Solicitud #{solicitud.Id} registrada exitosamente para {solicitud.Cliente}!";
            return RedirectToAction(nameof(Registrar));
        }

        TempData["MensajeError"] = "Por favor, complete todos los campos obligatorios.";
        return View(solicitud);
    }

    // GET: Solicitud/Listado
    [HttpGet]
    public async Task<IActionResult> Listado()
    {
        var solicitudes = await _context.SolicitudesServicio
            .OrderByDescending(s => s.FechaRegistro)
            .ToListAsync();
        return View(solicitudes);
    }
}
