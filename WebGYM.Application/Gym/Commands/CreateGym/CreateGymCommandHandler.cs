using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Application.Interfaces;
using WebGYM.Domain;

namespace WebGYM.Application.Gym.Commands.CreateGym
{
   
    public class CreateGymCommandHandler
        :IRequestHandler<CreateGymCommand, Guid >
       
    {
        private readonly IWebGymDbContext _webGymDbContext;

        public CreateGymCommandHandler(IWebGymDbContext webGymDbContext)
        {
            _webGymDbContext = webGymDbContext;
        }

        public async Task<Guid> Handle(CreateGymCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserId = request.UserId,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
               
            };

            await _webGymDbContext.Users.AddAsync(user, cancellationToken);
            await _webGymDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
    
    
}
