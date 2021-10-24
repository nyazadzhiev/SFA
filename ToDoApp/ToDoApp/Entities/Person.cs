using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Entities
{
    public abstract class Person : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
