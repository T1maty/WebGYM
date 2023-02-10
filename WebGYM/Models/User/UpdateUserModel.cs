using AutoMapper;
using WebGYM.Application.Common.Mappings;
using WebGYM.Application.Gym.Commands.User.UpdateUser;

namespace WebAPI.Models.User
{
    public class UpdateUserModel : IMappable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {

            profile.CreateMap<UpdateUserModel, UpdateUserCommand>();
        }
    }
}
