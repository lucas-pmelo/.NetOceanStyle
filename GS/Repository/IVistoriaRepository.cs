using GS.Models;

namespace GS.Repository;

public interface IVistoriaRepository
{
    Task<List<Vistoria>> ListarTodos();
    Task<Vistoria> ListarUm(int id);
    Task<Vistoria> Inserir(Vistoria vistoria);
    Task<Vistoria> Alterar(int id, Vistoria model);
    Task<Vistoria> Excluir(int id);
}