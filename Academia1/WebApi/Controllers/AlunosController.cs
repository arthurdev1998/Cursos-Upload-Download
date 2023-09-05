using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repositories.Interfaces;
using Repositories.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        

        private readonly AlunoRepository _aluno;
        private readonly IMapper _mapper;

        public AlunosController( AlunoRepository aluno, IMapper mapper)
        {
            
            _aluno = aluno;
            _mapper = mapper;
           
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(Aluno aluno)
        {
           
            await _aluno.Insert(aluno);
            return Ok("Aluno registrado com sucesso!");
        }


        [HttpGet("TodosOsAlunosPorCurso/{Id}")]
        public async Task<IActionResult> ObterTodosCursos(int Id)
        {
                return Ok(await _aluno.ListarAlunosPorCursos(Id));            
        }

        [HttpGet]
        public async Task<IActionResult> ObtertodosOsAlunos()
        {
              return Ok(await _aluno.GetAll());
            
        }



        [HttpGet("TodosOsAlunos/{pesquisa}")]
        public async Task<IActionResult> ObterTodosCursos(string pesquisa)
        {

            {

                var resultado = await _aluno.ListarAlunosPeloNome(pesquisa);

                return Ok(resultado.ToList());
            }
        }

       


    }
}
