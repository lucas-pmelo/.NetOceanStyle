using GS.Models;

namespace GS.Repository;

public interface IEnderecoRepository
{
    Task<List<Endereco>> ListarTodos();
    Task<Endereco> ListarUm(int id);
    Task<Endereco> Inserir(Endereco endereco);
    Task<Endereco> Alterar(int id, Endereco model);
    Task<Endereco> Excluir(int id);
}