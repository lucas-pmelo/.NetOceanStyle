using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GS.Controllers;

public class InspetorController : Controller
{
    private readonly IInspetorRepository _inspetorRepository;
    
    public InspetorController(IInspetorRepository inspetorRepository)
    {
        _inspetorRepository = inspetorRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var inspetores = await _inspetorRepository.ListarTodos();
        
        return View(inspetores);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? id)
    {
        var inspetor = await _inspetorRepository.ListarUm(id ?? 0);

        return View(inspetor);
    }

    //INSERIR
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Inspetor inspetor)
    {
        if (ModelState.IsValid)
        {
            await _inspetorRepository.Inserir(inspetor);

            return RedirectToAction("Index");
        }
        
        return View(inspetor);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inspetor = await _inspetorRepository.ListarUm(id ?? 0);
        
        return View(inspetor);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Inspetor inspetor)
    {
        if (ModelState.IsValid)
        {
            await _inspetorRepository.Alterar(id, inspetor);

            return RedirectToAction("Index");
        }
        
        return View(inspetor);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inspetor = await _inspetorRepository.ListarUm(id ?? 0);

        return View(inspetor);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _inspetorRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}