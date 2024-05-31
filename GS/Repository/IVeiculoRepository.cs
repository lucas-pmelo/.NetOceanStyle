using GS.Models;

namespace GS.Repository;

public interface IVeiculoRepository
{
    Task<List<Veiculo>> ListarTodos();
    Task<Veiculo> ListarUm(int tie);
    Task<Veiculo> Inserir(Veiculo veiculo);
    Task<Veiculo> Alterar(int tie, Veiculo model);
    Task<Veiculo> Excluir(int tie);
}