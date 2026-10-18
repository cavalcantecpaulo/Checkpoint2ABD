using Microsoft.AspNetCore.Mvc;
using RegistraNuclearTech.Models;
using RegistraNuclearTech.Repositories;

namespace RegistraNuclearTech.Controllers;

public class AcontecimentoNuclearController : Controller
{
    private readonly IAcontecimentoNuclearRepository _repository;

    public AcontecimentoNuclearController(IAcontecimentoNuclearRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Index(string? termoBusca)
    {
        ViewData["TermoAtual"] = termoBusca;

        IEnumerable<AcontecimentoNuclear> acontecimentos = !string.IsNullOrWhiteSpace(termoBusca)
            ? _repository.BuscarPorPais(termoBusca.Trim())
            : _repository.ListarTodos();

        return View(acontecimentos);
    }

    [HttpGet]
    public IActionResult Detalhes(int id)
    {
        var acontecimento = _repository.BuscarAcontecimentoPorId(id);
        if (acontecimento == null)
        {
            return NotFound();
        }

        return View(acontecimento);
    }

    [HttpGet]
    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Criar(AcontecimentoNuclear acontecimento)
    {
        if (!ModelState.IsValid)
        {
            return View(acontecimento);
        }

        _repository.Criar(acontecimento);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Atualizar(int id)
    {
        var acontecimento = _repository.BuscarAcontecimentoPorId(id);
        if (acontecimento == null)
        {
            return NotFound();
        }

        return View(acontecimento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Atualizar(int id, AcontecimentoNuclear acontecimento)
    {
        if (id != acontecimento.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(acontecimento);
        }

        var atualizado = _repository.Atualizar(acontecimento);
        if (atualizado == null)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        var acontecimento = _repository.BuscarAcontecimentoPorId(id);
        if (acontecimento == null)
        {
            return NotFound();
        }

        return View(acontecimento);
    }

    [HttpPost, ActionName("Excluir")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(int id)
    {
        _repository.Apagar(id);
        return RedirectToAction(nameof(Index));
    }
}
