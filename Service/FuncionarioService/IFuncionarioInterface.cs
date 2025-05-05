using Api_Completa.Models;

namespace Api_Completa.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionrios();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionaroById(int id);
        Task<ServiceResponse<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editadoFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeletaFuncionario(int id);
        Task<ServiceResponse<FuncionarioModel>> InativaFuncionario (int id);
    }
}
