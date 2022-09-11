using Application.Features.GitHubAddresses.Dtos;
using Application.Features.GitHubAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Commands.CreateGitHubAddress
{
    public class CreateGitHubAddressCommand : IRequest<CreatedGitHubAddressDto>
    {
        public string Url { get; set; }
        public int UserId { get; set; }

        public class CreateGitHubAddressCommandHandler : IRequestHandler<CreateGitHubAddressCommand, CreatedGitHubAddressDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubAddressRepository _gitHubAddressrepository;
            private readonly GitHubAddressBusinessRules _gitHubAddressBusinessRules;

            public CreateGitHubAddressCommandHandler(IMapper mapper, IGitHubAddressRepository gitHubAddressrepository, GitHubAddressBusinessRules gitHubAddressBusinessRules)
            {
                _mapper = mapper;
                _gitHubAddressrepository = gitHubAddressrepository;
                _gitHubAddressBusinessRules = gitHubAddressBusinessRules;
            }

            public async Task<CreatedGitHubAddressDto> Handle(CreateGitHubAddressCommand request, CancellationToken cancellationToken)
            {
                GitHubAddress mappedGitHubAddress = _mapper.Map<GitHubAddress>(request);
                GitHubAddress createdGitHubAddress = await _gitHubAddressrepository.AddAsync(mappedGitHubAddress);
                CreatedGitHubAddressDto createdGitHubAddressDto = _mapper.Map<CreatedGitHubAddressDto>(createdGitHubAddress);
                return createdGitHubAddressDto;
            }
        }
    }
}
