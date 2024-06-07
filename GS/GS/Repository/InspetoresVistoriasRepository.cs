using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class InspetoresVistoriasRepository : IInspetoresVistoriasRepository
    {
        private readonly Contexto _contexto;

        public InspetoresVistoriasRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<InspetoresVistorias>> ListarTodos()
        {
            var listaInspetoresVistorias = await _contexto.InspetoresVistorias
                                                          .Include(iv => iv.Inspetor) 
                                                          .Include(iv => iv.Vistoria) 
                                                          .ToListAsync();

            return listaInspetoresVistorias;
        }

        //LISTAR UM
        public async Task<InspetoresVistorias> ListarUm(int id)
        {
            var inspetoresVistorias = await _contexto.InspetoresVistorias
                                                     .Include(iv => iv.Inspetor) 
                                                     .Include(iv => iv.Vistoria) 
                                                     .FirstOrDefaultAsync(x => x.Id == id);

            if (inspetoresVistorias is null)
            {
                return new InspetoresVistorias();
            }

            return inspetoresVistorias;
        }

        //INSERIR
        public async Task<InspetoresVistorias> Inserir(InspetoresVistorias inspetoresVistorias)
        {
            await _contexto.InspetoresVistorias.AddAsync(inspetoresVistorias);
            await _contexto.SaveChangesAsync();

            return inspetoresVistorias;
        }

        //ALTERAR
        public async Task<InspetoresVistorias> Alterar(int id, InspetoresVistorias model)
        {
            var inspetoresVistorias = await _contexto.InspetoresVistorias.FirstOrDefaultAsync(x => x.Id == id);

            if (inspetoresVistorias is not null)
            {
                inspetoresVistorias.InspetorId = model.InspetorId;
                inspetoresVistorias.VistoriaId = model.VistoriaId;

                _contexto.InspetoresVistorias.Update(inspetoresVistorias);
                await _contexto.SaveChangesAsync();

                return inspetoresVistorias;
            }

            return model;
        }

        //EXCLUIR
        public async Task<InspetoresVistorias> Excluir(int id)
        {
            var inspetoresVistorias = await _contexto.InspetoresVistorias.FirstOrDefaultAsync(x => x.Id == id);

            if (inspetoresVistorias is not null)
            {
                _contexto.InspetoresVistorias.Remove(inspetoresVistorias);
                await _contexto.SaveChangesAsync();

                return inspetoresVistorias;
            }

            return new InspetoresVistorias();
        }
    }
}
