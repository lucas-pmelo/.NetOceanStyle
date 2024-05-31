using GS.Models;

namespace GS.Repository;

public interface IEstadoRepository
{
    Task<List<Estado>> ListarTodos();
    Task<Estado> ListarUm(int id);
    Task<Estado> Inserir(Estado estado);
    Task<Estado> Alterar(int id, Estado model);
    Task<Estado> Excluir(int id);
}