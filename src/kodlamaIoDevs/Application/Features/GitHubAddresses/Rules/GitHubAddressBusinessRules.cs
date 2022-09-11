using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Rules
{
    public class GitHubAddressBusinessRules
    {
        private readonly IGitHubAddressRepository _gitHubAddressRepository;

        public GitHubAddressBusinessRules(IGitHubAddressRepository gitHubAddressRepository)
        {
            _gitHubAddressRepository = gitHubAddressRepository;
        }


        public async Task GitHubAddressShouldExistWhenDeleted(int id)
        {
            GitHubAddress? result = await _gitHubAddressRepository.GetAsync(g => g.Id == id);
            if (result == null) throw new BusinessException("To be deleted GitHub address does not exist.");
        }

        public async Task<GitHubAddress> GitHubAddressShouldExistWhenUpdated(int id)
        {
            GitHubAddress? result = await _gitHubAddressRepository.GetAsync(g => g.Id == id);
            if (result == null) throw new BusinessException("To be updated GitHub address does not exist.");
            return result;
        }
    }
}
