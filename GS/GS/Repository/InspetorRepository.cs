using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class InspetorRepository : IInspetorRepository
    {
        private readonly Contexto _contexto;

        public InspetorRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<Inspetor>> ListarTodos()
        {
            var listaInspetor = await _contexto.Inspetores
                                               .Include(i => i.InspetoresVistorias) // Include InspetoresVistorias
                                               .ToListAsync();

            return listaInspetor;
        }

        //LISTAR UM
        public async Task<Inspetor> ListarUm(int id)
        {
            var inspetor = await _contexto.Inspetores
                                          .Include(i => i.InspetoresVistorias) // Include InspetoresVistorias
                                          .FirstOrDefaultAsync(x => x.Id == id);

            if (inspetor is null)
            {
                return new Inspetor();
            }

            return inspetor;
        }

        //INSERIR
        public async Task<Inspetor> Inserir(Inspetor inspetor)
        {
            await _contexto.Inspetores.AddAsync(inspetor);
            await _contexto.SaveChangesAsync();

            return inspetor;
        }

        //ALTERAR
        public async Task<Inspetor> Alterar(int id, Inspetor model)
        {
            var inspetor = await _contexto.Inspetores.FirstOrDefaultAsync(x => x.Id == id);

            if (inspetor is not null)
            {
                inspetor.Rg = model.Rg;
                inspetor.Nome = model.Nome;
                inspetor.Especializacao = model.Especializacao;
                inspetor.Telefone = model.Telefone;

                _contexto.Inspetores.Update(inspetor);
                await _contexto.SaveChangesAsync();

                return inspetor;
            }

            return model;
        }

        //EXCLUIR
        public async Task<Inspetor> Excluir(int id)
        {
            var inspetor = await _contexto.Inspetores.FirstOrDefaultAsync(x => x.Id == id);

            if (inspetor is not null)
            {
                _contexto.Inspetores.Remove(inspetor);
                await _contexto.SaveChangesAsync();

                return inspetor;
            }

            return new Inspetor();
        }
    }
}
