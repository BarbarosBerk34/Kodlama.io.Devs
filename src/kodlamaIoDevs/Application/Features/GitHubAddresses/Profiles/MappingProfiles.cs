using Application.Features.GitHubAddresses.Commands.CreateGitHubAddress;
using Application.Features.GitHubAddresses.Commands.DeleteGitHubAddress;
using Application.Features.GitHubAddresses.Commands.UpdateGitHubAddress;
using Application.Features.GitHubAddresses.Dtos;
using Application.Features.GitHubAddresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GitHubAddress, GitHubAddressListDto>()
                .ForMember(c => c.UserFirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(c => c.UserLastName, opt => opt.MapFrom(c => c.User.LastName))
                .ReverseMap();
            CreateMap<IPaginate<GitHubAddress>, GitHubAddressListModel>().ReverseMap();
            CreateMap<GitHubAddress, CreatedGitHubAddressDto>().ReverseMap();
            CreateMap<GitHubAddress, CreateGitHubAddressCommand>().ReverseMap();
            CreateMap<GitHubAddress, UpdatedGitHubAddressDto>().ReverseMap();
            CreateMap<GitHubAddress, UpdateGitHubAddressCommand>().ReverseMap();
            CreateMap<GitHubAddress, DeletedGitHubAddressDto>().ReverseMap();
            CreateMap<GitHubAddress, DeleteGitHubAddressCommand>().ReverseMap();
        }
    }
}
