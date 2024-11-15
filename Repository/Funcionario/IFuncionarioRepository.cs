using ControleDeFuncionarios.Models;

namespace ControleDeFuncionarios.Repository.Funcionario
{
    public interface IFuncionarioRepository
    {
        Task<ResponseModel<List<FuncionarioModel>>> GetAllFuncionarios();
        Task<ResponseModel<FuncionarioModel>> GetByIdFuncionario(int id);
        Task<ResponseModel<List<FuncionarioModel>>>CreateFuncionario(FuncionarioModel funcionario);
        Task<ResponseModel<List<FuncionarioModel>>>UpdateFuncionario(FuncionarioModel funcionario);
        Task<ResponseModel<List<FuncionarioModel>>>DeleteFuncionario(int id);
        Task<ResponseModel<List<FuncionarioModel>>> InativarFuncionario(int id);
    }
}
