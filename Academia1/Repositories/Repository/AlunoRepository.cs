using AutoMapper;
using Data.Contexto.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AlunoRepository(DataContext dataContext, IMapper mapper) : base(dataContext)
        {

            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IList<AlunoDto>> ListarAlunosPorCursos(int IdCurso) 
        {
            var alunosQuery = _dataContext.Set<Aluno>();
            var alunosPorCurso = await alunosQuery.Where(x => x.IdCursos == IdCurso).ToListAsync();
            var alunoDto = _mapper.Map<List<AlunoDto>>(alunosPorCurso.ToList());

            return alunoDto;
        }

        public async Task<IList<AlunoDto>> ListarAlunosPeloNome(string pesquisa)
        {
            var alunosQuery =  _dataContext.Set<Aluno>();

            var alunosPeloNome  =  from item in alunosQuery
                                  where item.Nome.Contains(pesquisa)
                                                  select item;

            var alunosPeloNomeLista = await alunosPeloNome.ToListAsync();

            var alunosPeloNomeDto = _mapper.Map<List<AlunoDto>>(alunosPeloNomeLista);

            return alunosPeloNomeDto;
        }

    }
}
