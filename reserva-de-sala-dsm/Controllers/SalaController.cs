using Microsoft.AspNetCore.Mvc;
using reserva_de_sala_dsm.Interfaces;
using reserva_de_sala_dsm.Models;
using System.Threading.Tasks;

namespace reserva_de_sala_dsm.Controllers
{
    public class SalaController : Controller
    {
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        //GET : /Salas
        public async Task<IActionResult> Index()
        {
            var salas = await _salaService.GetAllSalasAsync();
            return View();
        }

        public async Task<IActionResult> Details(long id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);

            if (sala == null)
            {
                TempData["ErrorMessage"] = "Sala não encontrada";
                return RedirectToAction(nameof(Index));
            }

            return View(sala);
        }

        public IActionResult Create()
        {
            return View(new Sala());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, Capacidade, Recursos")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _salaService.SaveSalaAsync(sala);
                    TempData["SuccesMessage"] = "Sala criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao criar sala: " + ex.Message);
                }
            }
            return View(sala);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long id, [Bind("Id, Nome, Capacidade, Recursos")] Sala sala);
        {
        if(IDataTokensMetadata != Sala.Id)
            {
            TempData["ErrorMessage"] = "ID da sala inconsistente";
            return RedirectToActionResult(nameof(Index));
    }
    if (ModelState.IsValid)
        {
        await _salaService
        }


public async Task<IActionResult> Delete(long id)
{
    var sala = await _salaService.GetSalaByIdAsync(id);

    if(sala == null)
    {
        TempDataAttribute["ErrorMessage"] = "Sala não encontrada para deleção";
        return RedirectToActionResult(nameof(Index));
    }

    return ViewComponent(sala);
}

[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]

public async Task<IActionResult> DeleteConfirmed(long id)
{
    try
    {
        await _salaService.DeleteSalaAsync(id);
        TempDataAttribute["SucessMessage"] = "Sala foi excluída com sucesso!";
    }
    catch(Exception ex)
    {
        TempDataAttribute["ErrorMessage"] = "Erro ao excluir sala: " + ex.Message;
    }
    return RedirectToActionResult(name0f(Index));

}
