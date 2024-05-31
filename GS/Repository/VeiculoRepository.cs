using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly Contexto _contexto;

        public VeiculoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<Veiculo>> ListarTodos()
        {
            var listaVeiculo = await _contexto.Veiculos
                                              .Include(v => v.Empresa)
                                              .Include(v => v.Vistorias)
                                              .ToListAsync();

            return listaVeiculo;
        }

        //LISTAR UM
        public async Task<Veiculo> ListarUm(int tie)
        {
            var veiculo = await _contexto.Veiculos
                                         .Include(v => v.Empresa)
                                         .Include(v => v.Vistorias)
                                         .FirstOrDefaultAsync(x => x.Tie == tie);

            if (veiculo is null)
            {
                return new Veiculo();
            }

            return veiculo;
        }

        //INSERIR
        public async Task<Veiculo> Inserir(Veiculo veiculo)
        {
            await _contexto.Veiculos.AddAsync(veiculo);
            await _contexto.SaveChangesAsync();

            return veiculo;
        }

        //ALTERAR
        public async Task<Veiculo> Alterar(int tie, Veiculo model)
        {
            var veiculo = await _contexto.Veiculos.FirstOrDefaultAsync(x => x.Tie == tie);

            if (veiculo is not null)
            {
                veiculo.Nome = model.Nome;
                veiculo.Tipo = model.Tipo;
                veiculo.TipoMotor = model.TipoMotor;
                veiculo.Sonar = model.Sonar;
                veiculo.EmpresaId = model.EmpresaId;
                veiculo.LinkImagem = model.LinkImagem;

                _contexto.Veiculos.Update(veiculo);
                await _contexto.SaveChangesAsync();

                return veiculo;
            }

            return model;
        }

        //EXCLUIR
        public async Task<Veiculo> Excluir(int tie)
        {
            var veiculo = await _contexto.Veiculos.FirstOrDefaultAsync(x => x.Tie == tie);

            if (veiculo is not null)
            {
                _contexto.Veiculos.Remove(veiculo);
                await _contexto.SaveChangesAsync();

                return veiculo;
            }

            return new Veiculo();
        }
    }
}
