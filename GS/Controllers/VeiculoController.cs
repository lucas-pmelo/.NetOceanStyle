using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GS.Controllers;

public class VeiculoController : Controller
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IEmpresaRepository _empresaRepository;
    
    public VeiculoController(IVeiculoRepository veiculoRepository, IEmpresaRepository empresaRepository)
    {
        _veiculoRepository = veiculoRepository;
        _empresaRepository = empresaRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var veiculos = await _veiculoRepository.ListarTodos();
        
        return View(veiculos);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? tie)
    {
        var veiculo = await _veiculoRepository.ListarUm(tie ?? 0);

        return View(veiculo);
    }

    //INSERIR
    public async Task<IActionResult> Create()
    {
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Veiculo veiculo)
    {
        if (ModelState.IsValid)
        {
            await _veiculoRepository.Inserir(veiculo);

            return RedirectToAction("Index");
        }
        
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        return View(veiculo);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? tie)
    {
        if (tie == null)
        {
            return NotFound();
        }

        var veiculo = await _veiculoRepository.ListarUm(tie ?? 0);
        
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        
        return View(veiculo);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int tie, Veiculo veiculo)
    {
        if (ModelState.IsValid)
        {
            await _veiculoRepository.Alterar(tie, veiculo);

            return RedirectToAction("Index");
        }
        
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        
        return View(veiculo);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? tie)
    {
        if (tie == null)
        {
            return NotFound();
        }

        var veiculo = await _veiculoRepository.ListarUm(tie ?? 0);

        return View(veiculo);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int tie)
    {
        await _veiculoRepository.Excluir(tie);
        return RedirectToAction("Index");
    }
}