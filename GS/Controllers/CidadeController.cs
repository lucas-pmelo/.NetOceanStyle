using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GS.Controllers;

public class CidadeController : Controller
{
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IEstadoRepository _estadoRepository;
    
    public CidadeController(ICidadeRepository cidadeRepository, IEstadoRepository estadoRepository)
    {
        _cidadeRepository = cidadeRepository;
        _estadoRepository = estadoRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var cidades = await _cidadeRepository.ListarTodos();
        
        return View(cidades);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? id)
    {
        var cidade = await _cidadeRepository.ListarUm(id ?? 0);

        return View(cidade);
    }

    //INSERIR
    public async Task<IActionResult> Create()
    {
        ViewBag.Estados = await _estadoRepository.ListarTodos();
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Cidade cidade)
    {
        if (ModelState.IsValid)
        {
            await _cidadeRepository.Inserir(cidade);

            return RedirectToAction("Index");
        }
        
        ViewBag.Estados = await _estadoRepository.ListarTodos();
        return View(cidade);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cidade = await _cidadeRepository.ListarUm(id ?? 0);
        
        ViewBag.Estados = await _estadoRepository.ListarTodos();
        
        return View(cidade);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Cidade cidade)
    {
        if (ModelState.IsValid)
        {
            cidade.Id = id;
            
            await _cidadeRepository.Alterar(id, cidade);

            return RedirectToAction("Index");
        }
        
        ViewBag.Estados = await _estadoRepository.ListarTodos();
        
        return View(cidade);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cidade = await _cidadeRepository.ListarUm(id ?? 0);

        return View(cidade);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _cidadeRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}