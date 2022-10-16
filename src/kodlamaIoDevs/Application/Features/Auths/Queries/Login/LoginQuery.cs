using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthServices;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Queries.LoginUser
{
    public class LoginQuery : IRequest<LoggedInDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoggedInDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public LoginQueryHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<LoggedInDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {

                await _authBusinessRules.UserShouldBeExistWhenLoggedIn(request.UserForLoginDto.Email);

                User? existingUser = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                AuthBusinessRules.CredentialsShouldBeMatchWhenLoggedIn(existingUser!, request.UserForLoginDto.Password);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(existingUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(existingUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoggedInDto loggedInDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken,
                };

                return loggedInDto;
            }
        }
    }
}
