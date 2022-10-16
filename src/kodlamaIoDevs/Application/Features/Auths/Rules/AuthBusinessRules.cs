using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Entered email is already registered.");
        }

        public async Task UserShouldBeExistWhenLoggedIn(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new BusinessException("Requested user does not exist.");
        }

        public static void CredentialsShouldBeMatchWhenLoggedIn(User user, string password)
        {
            bool isUserPasswordVerified = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (!isUserPasswordVerified) throw new BusinessException("User credentials does not match.");
        }
    }
}
