using ControleDeFuncionarios.Models;
using ControleDeFuncionarios.Repository.Funcionario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _repository;
        public FuncionarioController(IFuncionarioRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("ListarTodosFuncioanrios")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> GetAllFuncionario()
        {
            var funcionario = await _repository.GetAllFuncionarios();
            return Ok(funcionario);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<FuncionarioModel>>>GetByIdFuncionario(int id)
        {
            var funcionario = await _repository.GetByIdFuncionario(id);
            return Ok(funcionario);
        }



        [HttpPost("CriarFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>>CreateFuncionario(FuncionarioModel funcionario)
        {
            var funcionarioNovo = await _repository.CreateFuncionario(funcionario);
            return Ok(funcionarioNovo);
        }


        [HttpPut("InativarFunionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>>InativarFuncionario(int id)
        {
            var funcionario = await _repository.InativarFuncionario(id);
            return Ok(funcionario);
        }

        [HttpPut("EditarFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>>UpdateFuncionario(FuncionarioModel funcionario)
        {
            var funcionarioEditado = await _repository.UpdateFuncionario(funcionario);
            return Ok(funcionarioEditado);
        }



        [HttpDelete("DeletarFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>>ExcluirFuncionario(int id)
        {
            var funcionario = await _repository.DeleteFuncionario(id);
            return Ok(funcionario);
        }
    }
}
