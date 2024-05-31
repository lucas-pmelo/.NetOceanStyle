using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GS.Controllers;

public class InspetoresVistoriasController : Controller
{
    private readonly IInspetoresVistoriasRepository _inspetoresVistoriaRepository;
    private readonly IVistoriaRepository _vistoriaRepository;
    private readonly IInspetorRepository _inspetorRepository;
    
    public InspetoresVistoriasController(IInspetoresVistoriasRepository inspetoresVistoriaRepository, IVistoriaRepository vistoriaRepository, IInspetorRepository inspetorRepository)
    {
        _inspetoresVistoriaRepository = inspetoresVistoriaRepository;
        _vistoriaRepository = vistoriaRepository;
        _inspetorRepository = inspetorRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var inspetoresVistorias = await _inspetoresVistoriaRepository.ListarTodos();
        
        return View(inspetoresVistorias);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? id)
    {
        var inspetoresVistoria = await _inspetoresVistoriaRepository.ListarUm(id ?? 0);

        return View(inspetoresVistoria);
    }

    //INSERIR
    public async Task<IActionResult> Create()
    {
        ViewBag.Vistorias = await _vistoriaRepository.ListarTodos();
        ViewBag.Inspetores = await _inspetorRepository.ListarTodos();
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(InspetoresVistorias inspetoresVistoria)
    {
        if (ModelState.IsValid)
        {
            await _inspetoresVistoriaRepository.Inserir(inspetoresVistoria);

            return RedirectToAction("Index");
        }
        
        ViewBag.Vistorias = await _vistoriaRepository.ListarTodos();
        ViewBag.Inspetores = await _inspetorRepository.ListarTodos();
        return View(inspetoresVistoria);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inspetoresVistoria = await _inspetoresVistoriaRepository.ListarUm(id ?? 0);
        
        ViewBag.Vistorias = await _vistoriaRepository.ListarTodos();
        ViewBag.Inspetores = await _inspetorRepository.ListarTodos();
        return View(inspetoresVistoria);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, InspetoresVistorias inspetoresVistoria)
    {
        if (ModelState.IsValid)
        {
            await _inspetoresVistoriaRepository.Alterar(id, inspetoresVistoria);

            return RedirectToAction("Index");
        }
        
        ViewBag.Vistorias = await _vistoriaRepository.ListarTodos();
        ViewBag.Inspetores = await _inspetorRepository.ListarTodos();
        return View(inspetoresVistoria);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inspetoresVistoria = await _inspetoresVistoriaRepository.ListarUm(id ?? 0);

        ViewBag.Vistorias = await _vistoriaRepository.ListarTodos();
        ViewBag.Inspetores = await _inspetorRepository.ListarTodos();
        return View(inspetoresVistoria);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _inspetoresVistoriaRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}