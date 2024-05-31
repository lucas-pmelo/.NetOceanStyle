using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly Contexto _contexto;

        public EstadoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<Estado>> ListarTodos()
        {
            var listaEstado = await _contexto.Estados
                                             .Include(e => e.Cidades) 
                                             .ToListAsync();

            return listaEstado;
        }

        //LISTAR UM
        public async Task<Estado> ListarUm(int id)
        {
            var estado = await _contexto.Estados
                                        .Include(e => e.Cidades) 
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (estado is null)
            {
                return new Estado();
            }

            return estado;
        }

        //INSERIR
        public async Task<Estado> Inserir(Estado estado)
        {
            await _contexto.Estados.AddAsync(estado);
            await _contexto.SaveChangesAsync();

            return estado;
        }

        //ALTERAR
        public async Task<Estado> Alterar(int id, Estado model)
        {
            var estado = await _contexto.Estados.FirstOrDefaultAsync(x => x.Id == id);

            if (estado is not null)
            {
                estado.Nome = model.Nome;
                estado.Sigla = model.Sigla;

                _contexto.Estados.Update(estado);
                await _contexto.SaveChangesAsync();

                return estado;
            }

            return model;
        }

        //EXCLUIR
        public async Task<Estado> Excluir(int id)
        {
            var estado = await _contexto.Estados.FirstOrDefaultAsync(x => x.Id == id);

            if (estado is not null)
            {
                _contexto.Estados.Remove(estado);
                await _contexto.SaveChangesAsync();

                return estado;
            }

            return new Estado();
        }
    }
}
