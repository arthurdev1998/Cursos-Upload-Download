using Data.Contexto.Context;
using Domain.Entities;
using Repositories.Base;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CursoRepository : BaseRepository<Cursos>, ICursoRepository
    {
        public CursoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
