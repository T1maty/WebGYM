using AutoMapper;
using WebGYM.Application.Common.Mappings;
using WebGYM.Application.Gym.Commands.User.CreateUser;

namespace WebAPI.Models.User
{
    public class CreateUserModel : IMappable
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserModel, CreateUserCommand>();
        }
    }
}
