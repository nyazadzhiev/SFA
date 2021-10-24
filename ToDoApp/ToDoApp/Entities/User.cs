using System;
using System.Collections.Generic;
using System.Text;


namespace ToDoApp.Entities
{
    class User : Person
    {
        public List<TaskList> ToDoList { get; set; }
        public List<TaskList> SharedToDoList { get; set; }
        public Admin Creator { get; set; }

        public User()
        {
            ToDoList = new List<TaskList>();
            SharedToDoList = new List<TaskList>();
        }
    }
}
