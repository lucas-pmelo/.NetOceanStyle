using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly Contexto _contexto;

        public EmpresaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<Empresa>> ListarTodos()
        {
            var listaEmpresa = await _contexto.Empresas
                                              .Include(e => e.Veiculos)  
                                              .Include(e => e.Enderecos) 
                                              .ToListAsync();

            return listaEmpresa;
        }

        //LISTAR UM
        public async Task<Empresa> ListarUm(int id)
        {
            var empresa = await _contexto.Empresas
                                         .Include(e => e.Veiculos)  
                                         .Include(e => e.Enderecos) 
                                         .FirstOrDefaultAsync(x => x.Id == id);

            if (empresa is null)
            {
                return new Empresa();
            }

            return empresa;
        }

        //INSERIR
        public async Task<Empresa> Inserir(Empresa empresa)
        {
            await _contexto.Empresas.AddAsync(empresa);
            await _contexto.SaveChangesAsync();

            return empresa;
        }

        //ALTERAR
        public async Task<Empresa> Alterar(int id, Empresa model)
        {
            var empresa = await _contexto.Empresas.FirstOrDefaultAsync(x => x.Id == id);

            if (empresa is not null)
            {
                empresa.Cnpj = model.Cnpj;
                empresa.Nome = model.Nome;
                empresa.Telefone = model.Telefone;
                empresa.Email = model.Email;

                _contexto.Empresas.Update(empresa);
                await _contexto.SaveChangesAsync();

                return empresa;
            }

            return model;
        }

        //EXCLUIR
        public async Task<Empresa> Excluir(int id)
        {
            var empresa = await _contexto.Empresas.FirstOrDefaultAsync(x => x.Id == id);

            if (empresa is not null)
            {
                _contexto.Empresas.Remove(empresa);
                await _contexto.SaveChangesAsync();

                return empresa;
            }

            return new Empresa();
        }
    }
}
