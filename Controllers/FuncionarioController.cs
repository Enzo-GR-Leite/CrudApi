using Api_Completa.Models;
using Api_Completa.Service.FuncionarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Completa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioService;

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncioanrio()
        {
            return Ok(await _funcionarioService.GetFuncionrios());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioService.CreateFuncionario(novoFuncionario));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById (int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioService.GetFuncionaroById(id);
            return Ok(serviceResponse);
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioService.InativaFuncionario(id);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionarioEditado)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioService.UpdateFuncionario(funcionarioEditado);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioService.DeletaFuncionario(id);

            return Ok(serviceResponse);
        }

        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioService = funcionarioInterface;
        }
    }
}
