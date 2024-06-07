using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GS.Controllers;

public class EmpresaController : Controller
{
    private readonly IEmpresaRepository _empresaRepository;
    
    public EmpresaController(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var empresas = await _empresaRepository.ListarTodos();
        
        return View(empresas);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? id)
    {
        var empresa = await _empresaRepository.ListarUm(id ?? 0);

        return View(empresa);
    }

    //INSERIR
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Empresa empresa)
    {
        if (ModelState.IsValid)
        {
            await _empresaRepository.Inserir(empresa);

            return RedirectToAction("Index");
        }
        
        return View(empresa);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empresa = await _empresaRepository.ListarUm(id ?? 0);
        
        return View(empresa);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Empresa empresa)
    {
        if (ModelState.IsValid)
        {
            await _empresaRepository.Alterar(id, empresa);

            return RedirectToAction("Index");
        }
        
        return View(empresa);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empresa = await _empresaRepository.ListarUm(id ?? 0);

        return View(empresa);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _empresaRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}