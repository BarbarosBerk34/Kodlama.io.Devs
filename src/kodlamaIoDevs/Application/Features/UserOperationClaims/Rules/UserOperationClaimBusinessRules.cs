using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public UserOperationClaimBusinessRules(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == userId);
            if (user == null) throw new BusinessException("This user does not exist");
        }

        public async Task OperationClaimShouldExistWhenRequested(int operationClaimId)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == operationClaimId);
            if (operationClaim == null) throw new BusinessException("This operation claim does not exist");
        }

        public void UserOperationClaimShouldExistWhenDeleted(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("User operation claim does not exist");
        }
    }
}
