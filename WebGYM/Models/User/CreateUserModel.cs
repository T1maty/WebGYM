using AutoMapper;
using WebGYM.Application.Common.Mappings;
using WebGYM.Application.Gym.Commands.User.CreateUser;

namespace WebAPI.Models.User
{
    public class CreateUserModel : IMappable
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserModel, CreateUserCommand>();
        }
    }
}
