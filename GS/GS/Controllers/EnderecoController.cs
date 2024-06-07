using GS.Models;
using GS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GS.Controllers;

public class EnderecoController : Controller
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IEmpresaRepository _empresaRepository;
    
    public EnderecoController(IEnderecoRepository enderecoRepository, ICidadeRepository cidadeRepository, IEmpresaRepository empresaRepository)
    {
        _enderecoRepository = enderecoRepository;
        _cidadeRepository = cidadeRepository;
        _empresaRepository = empresaRepository;
    }
    
    //LISTAR TODOS
    public async Task<IActionResult> Index()
    {
        var enderecos = await _enderecoRepository.ListarTodos();
        
        return View(enderecos);
    }
    
    //LISTAR UM
    public async Task<IActionResult> Details(int? id)
    {
        var endereco = await _enderecoRepository.ListarUm(id ?? 0);

        return View(endereco);
    }

    //INSERIR
    public async Task<IActionResult> Create()
    {
        ViewBag.Cidades = await _cidadeRepository.ListarTodos();
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Endereco endereco)
    {
        if (ModelState.IsValid)
        {
            await _enderecoRepository.Inserir(endereco);

            return RedirectToAction("Index");
        }
        
        ViewBag.Cidades = await _cidadeRepository.ListarTodos();
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        return View(endereco);
    }
    
    //ALTERAR
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var endereco = await _enderecoRepository.ListarUm(id ?? 0);
        
        ViewBag.Cidades = await _cidadeRepository.ListarTodos();
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        
        return View(endereco);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Endereco endereco)
    {
        if (ModelState.IsValid)
        {
            await _enderecoRepository.Alterar(id, endereco);

            return RedirectToAction("Index");
        }
        
        ViewBag.Cidades = await _cidadeRepository.ListarTodos();
        ViewBag.Empresas = await _empresaRepository.ListarTodos();
        
        return View(endereco);
    }
    
    //DELETAR
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var endereco = await _enderecoRepository.ListarUm(id ?? 0);
        
        ViewBag.Cidades = await _cidadeRepository.ListarTodos();
        ViewBag.Empresas = await _empresaRepository.ListarTodos();

        return View(endereco);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _enderecoRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}