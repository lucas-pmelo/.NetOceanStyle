using GS.Models;

namespace GS.Repository;

public interface IInspetoresVistoriasRepository
{
    Task<List<InspetoresVistorias>> ListarTodos();
    Task<InspetoresVistorias> ListarUm(int id);
    Task<InspetoresVistorias> Inserir(InspetoresVistorias inspetoresVistorias);
    Task<InspetoresVistorias> Alterar(int id, InspetoresVistorias model);
    Task<InspetoresVistorias> Excluir(int id);
}