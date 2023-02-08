using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGYM.Application.Gym.Commands.User.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
