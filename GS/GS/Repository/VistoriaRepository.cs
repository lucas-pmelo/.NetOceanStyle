using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class VistoriaRepository : IVistoriaRepository
    {
        private readonly Contexto _contexto;

        public VistoriaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<Vistoria>> ListarTodos()
        {
            var listaVistoria = await _contexto.Vistorias
                                               .Include(v => v.Veiculo) 
                                               .Include(v => v.InspetoresVistorias) 
                                               .ToListAsync();

            return listaVistoria;
        }

        //LISTAR UM
        public async Task<Vistoria> ListarUm(int id)
        {
            var vistoria = await _contexto.Vistorias
                                          .Include(v => v.Veiculo) 
                                          .Include(v => v.InspetoresVistorias) 
                                          .FirstOrDefaultAsync(x => x.Id == id);

            if (vistoria is null)
            {
                return new Vistoria();
            }

            return vistoria;
        }

        //INSERIR
        public async Task<Vistoria> Inserir(Vistoria vistoria)
        {
            await _contexto.Vistorias.AddAsync(vistoria);
            await _contexto.SaveChangesAsync();

            return vistoria;
        }

        //ALTERAR
        public async Task<Vistoria> Alterar(int id, Vistoria model)
        {
            var vistoria = await _contexto.Vistorias.FirstOrDefaultAsync(x => x.Id == id);

            if (vistoria is not null)
            {
                vistoria.Data = model.Data;
                vistoria.NivelRuido = model.NivelRuido;
                vistoria.Resultado = model.Resultado;
                vistoria.Observacoes = model.Observacoes;

                _contexto.Vistorias.Update(vistoria);
                await _contexto.SaveChangesAsync();

                return vistoria;
            }

            return model;
        }

        //EXCLUIR
        public async Task<Vistoria> Excluir(int id)
        {
            var vistoria = await _contexto.Vistorias.FirstOrDefaultAsync(x => x.Id == id);

            if (vistoria is not null)
            {
                _contexto.Vistorias.Remove(vistoria);
                await _contexto.SaveChangesAsync();

                return vistoria;
            }

            return new Vistoria();
        }
    }
}
