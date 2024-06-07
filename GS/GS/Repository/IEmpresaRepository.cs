using GS.Models;

namespace GS.Repository;

public interface IEmpresaRepository
{
    Task<List<Empresa>> ListarTodos();
    Task<Empresa> ListarUm(int id);
    Task<Empresa> Inserir(Empresa empresa);
    Task<Empresa> Alterar(int id, Empresa model);
    Task<Empresa> Excluir(int id);
}