using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGYM.Application.CQRS.Commands.SportClub.CreateSportClub
{
    public class CreateSportClubCommand : IRequest
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
