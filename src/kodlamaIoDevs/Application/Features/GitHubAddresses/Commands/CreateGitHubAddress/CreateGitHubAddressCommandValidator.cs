using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubAddresses.Commands.CreateGitHubAddress
{
    public class CreateGitHubAddressCommandValidator : AbstractValidator<CreateGitHubAddressCommand>
    {
        public CreateGitHubAddressCommandValidator()
        {
            RuleFor(c => c.Url).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
