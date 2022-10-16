using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Queries.LoginUser
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(c => c.UserForLoginDto.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.UserForLoginDto.Password).NotEmpty().MinimumLength(8);
        }
    }
}
