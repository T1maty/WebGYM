using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGYM.Application.CQRS.Commands.Actual.CreateActualCommand
{
    public class CreateActualCommand : IRequest
    {
        public string Category { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
