using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
