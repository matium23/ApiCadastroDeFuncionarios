using ControleDeFuncionarios.Context;
using ControleDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeFuncionarios.Repository.Funcionario
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;
        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel funcionario)
        {
            ResponseModel<List<FuncionarioModel>>response = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                if (funcionario == null)
                {
                    response.Dados = null;
                    response.Status = false;
                    response.Mensagem = "Iformar dados";
                    return response;
                }

                
                _context.Add(funcionario);
                await _context.SaveChangesAsync();


                response.Mensagem = "Registro adicionado com sucesso";
                response.Dados = _context.Funcionarios.ToList();
               
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
              
            }
            return response;
        }





        public async Task<ResponseModel<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ResponseModel<List<FuncionarioModel>>response = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id ==id);
                if (funcionario == null)
                {
                    response.Mensagem = "Registro não encontrado";
                    return response;
                }
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
                response.Mensagem = "Registro excluido com sucesso";
                response.Dados = await _context.Funcionarios.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> GetAllFuncionarios()
        {
           ResponseModel<List<FuncionarioModel>> response = new ResponseModel<List<FuncionarioModel>>();
            try
            {

                response.Dados = _context.Funcionarios.ToList();

                if(response.Dados.Count == 0)
                {
                    response.Mensagem = "Nenhum usuario encontrado";

                }

                response.Mensagem = "Registros listados com sucesso";
               
            }
            catch (Exception ex)
            {
                response.Mensagem= ex.Message;
                response.Status = false;
                
            }
            return response;
        }

        public async Task<ResponseModel<FuncionarioModel>> GetByIdFuncionario(int id)
        {
            ResponseModel<FuncionarioModel> response = new ResponseModel<FuncionarioModel>();
            try
            {
                var funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if (funcionario == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Registro nao encontrado";
                    response.Status = false;
                      
                    
                }
                response.Dados = funcionario;
                response.Mensagem = "Usuarios listado com sucesso";
                
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
               
            }
            return response;
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> InativarFuncionario(int id)
        {
            ResponseModel<List<FuncionarioModel>>response = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                
                var funcionario = _context.Funcionarios.FirstOrDefault(x=> x.Id == id);

                if (funcionario == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Usuario nao encontrado";
                    response.Status= false;
                }


                funcionario.Ativo = false;
                funcionario.DataAltercao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                response.Dados = _context.Funcionarios.ToList();
                response.Mensagem = "Registro inativado com sucesso";


                
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionario)
        {
            ResponseModel<List<FuncionarioModel>> response = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                var funcionarioEditado = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == funcionario.Id);

                if(funcionarioEditado == null)
                {
                    response.Mensagem = "Registro nao Encontrado";
                    return response;
                }
                funcionarioEditado.Nome = funcionario.Nome;
                funcionarioEditado.Sobrenome = funcionario.Sobrenome;
                funcionarioEditado.Turno = funcionario.Turno;
                funcionarioEditado.Departamento = funcionario.Departamento;
                funcionarioEditado.Ativo = funcionario.Ativo;
                funcionarioEditado.DataCriacao = funcionario.DataCriacao;
                funcionario.DataAltercao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionarioEditado);
                await _context.SaveChangesAsync();

                response.Mensagem = "Registro alterado com sucesso";
                response.Dados = await _context.Funcionarios.ToListAsync();
                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem += ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
