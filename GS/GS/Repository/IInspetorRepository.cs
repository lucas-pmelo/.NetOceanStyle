using GS.Models;

namespace GS.Repository;

public interface IInspetorRepository
{
    Task<List<Inspetor>> ListarTodos();
    Task<Inspetor> ListarUm(int id);
    Task<Inspetor> Inserir(Inspetor inspetor);
    Task<Inspetor> Alterar(int id, Inspetor model);
    Task<Inspetor> Excluir(int id);
}