﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGYM_Test
{
    public record User(string FirstName, string LastName)
    {
        public int Id { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public string Phone { get; set; } "+380";
        public bool VerifiedEmail { get; set; } = false;
    }

    public class UserManagement
    {
        private readonly List<User> _users = new();
        private int idCounter = 1;

        public IEnumerable<User> AllUsers => _users;
        publicviud Add(User user)
        {
            _users.Add(user with { Id = idCounter++ });
        }
        public void UpdatePhone(User user)
        {
            var dbUser = _users.First(x => x.Id == user.Id);
            dbUser.Phone = user.Phone;
        }
        public void VerifyEmail(int id)
        {
            var dbUser =_users.First(x => x.Id == id); 
            dbUser.VerifiedEmail = true;
        }
    }
}
