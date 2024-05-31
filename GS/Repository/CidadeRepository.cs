using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly Contexto _contexto;

        public CidadeRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<Cidade>> ListarTodos()
        {
            var listaCidade = await _contexto.Cidades
                                             .Include(c => c.Estado)
                                             .Include(c => c.Enderecos)
                                             .ToListAsync();

            return listaCidade;
        }

        //LISTAR UM
        public async Task<Cidade> ListarUm(int id)
        {
            var cidade = await _contexto.Cidades
                                        .Include(c => c.Estado)
                                        .Include(c => c.Enderecos)
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (cidade is null)
            {
                return new Cidade();
            }

            return cidade;
        }

        //INSERIR
        public async Task<Cidade> Inserir(Cidade cidade)
        {
            _contexto.Cidades.Add(cidade);
            await _contexto.SaveChangesAsync();

            return cidade;
        }

        //ALTERAR
        public async Task<Cidade> Alterar(int id, Cidade model)
        {
            var cidade = await _contexto.Cidades.FirstOrDefaultAsync(x => x.Id == id);

            if (cidade is not null)
            {
                cidade.Nome = model.Nome;
                cidade.EstadoId = model.EstadoId;

                _contexto.Cidades.Update(cidade);
                await _contexto.SaveChangesAsync();

                return cidade;
            }

            return model;
        }

        //EXCLUIR
        public async Task<Cidade> Excluir(int id)
        {
            var cidade = await _contexto.Cidades.FirstOrDefaultAsync(x => x.Id == id);

            if (cidade is not null)
            {
                _contexto.Cidades.Remove(cidade);
                await _contexto.SaveChangesAsync();

                return cidade;
            }

            return new Cidade();
        }
    }
}
