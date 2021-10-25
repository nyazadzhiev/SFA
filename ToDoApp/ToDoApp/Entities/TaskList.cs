using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Entities
{
    class TaskList : Entity
    {
        public string Title { get; set; }
        public List<Task> Tasks { get; set; }
        public User Owner { get; set; }

        public TaskList()
        {
            Tasks = new List<Task>();
        }
    }
}
