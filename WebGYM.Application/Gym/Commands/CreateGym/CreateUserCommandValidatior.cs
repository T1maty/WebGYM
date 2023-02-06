using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGYM.Application.Gym.Commands.CreateGym
{
    public class CreateUserCommandValidatior : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidatior()
        {
            RuleFor(CreateUserCommand => CreateUserCommand.FirstName).NotEmpty().MaximumLength(12);
            RuleFor(CreateUserCommand => CreateUserCommand.UserId);
        }
    }
}
