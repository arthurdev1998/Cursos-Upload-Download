using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class EntitiesToDto : Profile
    {
        public EntitiesToDto()
        {
            
            CreateMap<Aluno, AlunoDto>().ReverseMap();
        }
    }
}
