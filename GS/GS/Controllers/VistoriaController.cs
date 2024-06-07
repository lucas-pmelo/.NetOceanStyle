using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GS.Controllers;

public class VistoriaController : Controller
{
    private readonly IVistoriaRepository _vistoriaRepository;
    private readonly IVeiculoRepository _veiculoRepository;
    
    public VistoriaController(IVistoriaRepository vistoriaRepository, IVeiculoRepository veiculoRepository)
    {
        _vistoriaRepository = vistoriaRepository;
        _veiculoRepository = veiculoRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var vistorias = await _vistoriaRepository.ListarTodos();
        
        return View(vistorias);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? id)
    {
        var vistoria = await _vistoriaRepository.ListarUm(id ?? 0);

        return View(vistoria);
    }

    //INSERIR
    public async Task<IActionResult> Create()
    {
        ViewBag.Veiculos = await _veiculoRepository.ListarTodos();
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Vistoria vistoria)
    {
        if (ModelState.IsValid)
        {
            await _vistoriaRepository.Inserir(vistoria);

            return RedirectToAction("Index");
        }
        
        ViewBag.Veiculos = await _veiculoRepository.ListarTodos();
        return View(vistoria);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vistoria = await _vistoriaRepository.ListarUm(id ?? 0);
        
        ViewBag.Veiculos = await _veiculoRepository.ListarTodos();
        return View(vistoria);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Vistoria vistoria)
    {
        if (ModelState.IsValid)
        {
            await _vistoriaRepository.Alterar(id, vistoria);

            return RedirectToAction("Index");
        }
        
        ViewBag.Veiculos = await _veiculoRepository.ListarTodos();
        return View(vistoria);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vistoria = await _vistoriaRepository.ListarUm(id ?? 0);

        ViewBag.Veiculos = await _veiculoRepository.ListarTodos();
        
        return View(vistoria);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _vistoriaRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}