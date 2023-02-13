using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGYM.Application.CQRS.Commands.Actual.UpdateActual
{
    public class UpdateActualCommand : IRequest
    {
        public TimeSpan Duration { get; set; }
    }
}
