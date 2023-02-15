using AutoMapper;
using WebGYM.Application.Common.Mappings;
using WebGYM.Application.CQRS.Commands.SportClub.CreateSportClub;

namespace WebAPI.Models.SportClub
{
    public class CreateSportClubModel : IMappable
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSportClubModel, CreateSportClubCommand>();
        }
    }
}
