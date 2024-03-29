﻿using AutoMapper;
using System.ComponentModel.DataAnnotations;
using WebGYM.Application.Common.Mappings;
using WebGYM.Application.Gym.Commands.User.CreateUser;

namespace WebAPI.Models.User
{
    public class CreateUserModel : IMappable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserModel, CreateUserCommand>();
        }
    }
}
