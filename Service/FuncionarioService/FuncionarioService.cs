using Api_Completa.DataContext;
using Api_Completa.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Completa.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AplicationDbContext _context;

        public FuncionarioService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        } //finalizado

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeletaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse; 
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        } //finalizado

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionaroById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }  //finalizado

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionrios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        } // finalizado

        public async Task<ServiceResponse<FuncionarioModel>> InativaFuncionario(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.Ativo = false;

                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = funcionario;

            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        } // finalizado

        public async Task<ServiceResponse<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                if (editadoFuncionario.DataDeCriacao == editadoFuncionario.DataAlteracao)
                {
                    editadoFuncionario.DataDeCriacao = funcionario.DataDeCriacao;
                }
                else
                {
                    editadoFuncionario.DataAlteracao = DateTime.Now.ToLocalTime();
                }

                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = editadoFuncionario;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        } //finalizado
    }
}
