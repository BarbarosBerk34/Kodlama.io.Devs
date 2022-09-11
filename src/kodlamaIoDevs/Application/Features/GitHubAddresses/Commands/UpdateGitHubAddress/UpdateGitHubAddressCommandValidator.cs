using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Commands.UpdateGitHubAddress
{
    public class UpdateGitHubAddressCommandValidator: AbstractValidator<UpdateGitHubAddressCommand>
    {
        public UpdateGitHubAddressCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Url).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
