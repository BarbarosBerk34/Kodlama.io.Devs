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

namespace Application.Features.GitHubAddresses.Commands.UpdateGitHubAddress
{
    public class UpdateGitHubAddressCommand : IRequest<UpdatedGitHubAddressDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }

        public class UpdateGitHubAddressCommandHandler : IRequestHandler<UpdateGitHubAddressCommand, UpdatedGitHubAddressDto>
        {
            private readonly IGitHubAddressRepository _gitHubAddressRepository;
            private readonly IMapper _mapper;
            private readonly GitHubAddressBusinessRules _gitHubAddressBusinessRules;

            public UpdateGitHubAddressCommandHandler(IGitHubAddressRepository gitHubAddressRepository, IMapper mapper, GitHubAddressBusinessRules gitHubAddressBusinessRules)
            {
                _gitHubAddressRepository = gitHubAddressRepository;
                _mapper = mapper;
                _gitHubAddressBusinessRules = gitHubAddressBusinessRules;
            }

            public async Task<UpdatedGitHubAddressDto> Handle(UpdateGitHubAddressCommand request, CancellationToken cancellationToken)
            {
                GitHubAddress? existingGitHubAddress = await _gitHubAddressBusinessRules.GitHubAddressShouldExistWhenUpdated(request.Id);
                existingGitHubAddress.Url = request.Url;
                existingGitHubAddress.UserId = request.UserId;
                GitHubAddress updatedGitHubAddress = await _gitHubAddressRepository.UpdateAsync(existingGitHubAddress);
                UpdatedGitHubAddressDto updatedGitHubAddressDto = _mapper.Map<UpdatedGitHubAddressDto>(updatedGitHubAddress);
                return updatedGitHubAddressDto;
            }
        }
    }
}
