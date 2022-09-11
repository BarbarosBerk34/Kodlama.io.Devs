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

namespace Application.Features.GitHubAddresses.Commands.DeleteGitHubAddress
{
    public class DeleteGitHubAddressCommand : IRequest<DeletedGitHubAddressDto>
    {
        public int Id { get; set; }
        public class DeleteGitHubAddressCommandHandler : IRequestHandler<DeleteGitHubAddressCommand, DeletedGitHubAddressDto>
        {
            private readonly IGitHubAddressRepository _gitHubAddressRepository;
            private readonly IMapper _mapper;
            private readonly GitHubAddressBusinessRules _gitHubAddressBusinessRules;

            public DeleteGitHubAddressCommandHandler(IGitHubAddressRepository gitHubAddressRepository, IMapper mapper, GitHubAddressBusinessRules gitHubAddressBusinessRules)
            {
                _gitHubAddressRepository = gitHubAddressRepository;
                _mapper = mapper;
                _gitHubAddressBusinessRules = gitHubAddressBusinessRules;
            }

            public async Task<DeletedGitHubAddressDto> Handle(DeleteGitHubAddressCommand request, CancellationToken cancellationToken)
            {
                await _gitHubAddressBusinessRules.GitHubAddressShouldExistWhenDeleted(request.Id);

                GitHubAddress? gitHubAddress = await _gitHubAddressRepository.GetAsync(g => g.Id == request.Id);

                GitHubAddress deletedGitHubAddress = await _gitHubAddressRepository.DeleteAsync(gitHubAddress!);
                DeletedGitHubAddressDto deletedGitHubAddressDto = _mapper.Map<DeletedGitHubAddressDto>(deletedGitHubAddress);

                return deletedGitHubAddressDto;
            }
        }
    }
}
