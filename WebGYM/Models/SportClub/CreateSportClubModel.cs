using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebGYM.Application.Common.Mappings;
using WebGYM.Application.CQRS.Commands.SportClub.CreateSportClub;

namespace WebAPI.Models.SportClub
{
    public class CreateSportClubModel : IMappable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSportClubModel, CreateSportClubCommand>();
        }
    }
}
