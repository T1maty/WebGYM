using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Application.Common.Mappings;
using WebGYM.Domain;
using WebGYM.Domain.Entities;

namespace WebGYM.Application.Gym.Queries
{
    public class UserDetailsVm : IMapWith<User>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Email,
                opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.FirstName,
                opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userVm => userVm.LastName,
                opt => opt.MapFrom(user => user.LastName));

        }
    }
}
