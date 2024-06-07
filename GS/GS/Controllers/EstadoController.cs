using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GS.Controllers;

public class EstadoController : Controller
{
    private readonly IEstadoRepository _estadoRepository;
    
    public EstadoController(IEstadoRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var estados = await _estadoRepository.ListarTodos();
        
        return View(estados);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? id)
    {
        var estado = await _estadoRepository.ListarUm(id ?? 0);

        return View(estado);
    }

    //INSERIR
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Estado estado)
    {
        if (ModelState.IsValid)
        {
            await _estadoRepository.Inserir(estado);

            return RedirectToAction("Index");
        }
        
        return View(estado);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estado = await _estadoRepository.ListarUm(id ?? 0);
        
        return View(estado);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Estado estado)
    {
        if (ModelState.IsValid)
        {
            await _estadoRepository.Alterar(id, estado);

            return RedirectToAction("Index");
        }
        
        return View(estado);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estado = await _estadoRepository.ListarUm(id ?? 0);

        return View(estado);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _estadoRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}