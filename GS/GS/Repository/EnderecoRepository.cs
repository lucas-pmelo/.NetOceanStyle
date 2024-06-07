using GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly Contexto _contexto;

        public EnderecoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        //LISTAR TODOS
        public async Task<List<Endereco>> ListarTodos()
        {
            var listaEndereco = await _contexto.Enderecos
                                               .Include(e => e.Cidade)
                                               .Include(e => e.Empresa)
                                               .ToListAsync();

            return listaEndereco;
        }

        //LISTAR UM
        public async Task<Endereco> ListarUm(int id)
        {
            var endereco = await _contexto.Enderecos
                                          .Include(e => e.Cidade)
                                          .Include(e => e.Empresa)
                                          .FirstOrDefaultAsync(x => x.Id == id);

            if (endereco is null)
            {
                return new Endereco();
            }

            return endereco;
        }

        //INSERIR
        public async Task<Endereco> Inserir(Endereco endereco)
        {
            _contexto.Enderecos.Add(endereco);
            await _contexto.SaveChangesAsync();

            return endereco;
        }

        //ALTERAR
        public async Task<Endereco> Alterar(int id, Endereco model)
        {
            var endereco = await _contexto.Enderecos.FirstOrDefaultAsync(x => x.Id == id);

            if (endereco is not null)
            {
                endereco.Rua = model.Rua;
                endereco.Numero = model.Numero;
                endereco.Cep = model.Cep;
                endereco.CidadeId = model.CidadeId;
                endereco.EmpresaId = model.EmpresaId;

                _contexto.Enderecos.Update(endereco);
                await _contexto.SaveChangesAsync();

                return endereco;
            }

            return model;
        }

        //EXCLUIR
        public async Task<Endereco> Excluir(int id)
        {
            var endereco = await _contexto.Enderecos.FirstOrDefaultAsync(x => x.Id == id);

            if (endereco is not null)
            {
                _contexto.Enderecos.Remove(endereco);
                await _contexto.SaveChangesAsync();

                return endereco;
            }

            return new Endereco();
        }
    }
}
