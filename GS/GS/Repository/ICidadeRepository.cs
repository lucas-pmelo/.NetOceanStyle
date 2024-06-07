using GS.Models;

namespace GS.Repository;

public interface ICidadeRepository
{
    Task<List<Cidade>> ListarTodos();
    Task<Cidade> ListarUm(int id);
    Task<Cidade> Inserir(Cidade cidade);
    Task<Cidade> Alterar(int id, Cidade model);
    Task<Cidade> Excluir(int id);
}