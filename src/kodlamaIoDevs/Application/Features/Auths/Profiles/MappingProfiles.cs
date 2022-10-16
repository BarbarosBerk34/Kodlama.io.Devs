using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Queries.LoginUser;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

        }
    }
}
