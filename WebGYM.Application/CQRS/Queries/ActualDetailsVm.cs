using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Models;

namespace WebGYM.Application.CQRS.Queries
{
    public class ActualDetailsVm : IRequest
    {
        public string? Category { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Day { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<Actual, ActualDetailsVm>()
                .ForMember(ActualVm => ActualVm.Category,
                opt => opt.MapFrom(actual => actual.Category))
                .ForMember(ActualVm => ActualVm.Duration,
                opt => opt.MapFrom(actual => actual.Duration))
                .ForMember(ActualVm => ActualVm.Day,
                opt => opt.MapFrom(actual => actual.Day));
                
        }
    }
}
