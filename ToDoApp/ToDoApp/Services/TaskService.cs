using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Entities;

namespace ToDoApp.Services
{
    class TaskService
    {
        private readonly List<TaskList> tasks = new List<TaskList>();
        private int listIDGenerator = 0;        
        private int taskIDGenerator = 0;

        public List<TaskList> GetAllTaskLists()
        {
            return tasks;
        }

        public TaskList CreateTaskList(User user, string title)
        {
            listIDGenerator++;

            TaskList newTaskList = new TaskList()
            {
                Id = listIDGenerator,
                Title = title,
                Owner = user
            };

            user.ToDoList.Add(newTaskList);

            return newTaskList;   
            
        }

        public TaskList GetTaskList(User user, int id)
        {
            return user.ToDoList.FirstOrDefault(t => t.Id == id);
        }

        public Task GetTask(TaskList list, int id)
        {
            return list.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Task(TaskList list, User creator, string title, string description, bool isComplete)
        {
            taskIDGenerator++;

            Task newTask = new Task()
            {
                Creator = creator,
                Title = title,
                Description = description,
                IsComplete = isComplete,
                ToDoList = list,
                CreatedAt = DateTime.Now,
                Id = taskIDGenerator
            };

            list.Tasks.Add(newTask);
        }

        public bool CompleteTask(TaskList list, int taskId)
        {
            Task currentTask = list.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (currentTask != null)
            {
                currentTask.IsComplete = true;

                return true;
            }

            return false;
        }

        public bool EditTask(TaskList list, int taskId, int newId, string newTitle, string newDesc, bool newIscomplete)
        {
            Task currentTask = list.Tasks.FirstOrDefault(t => t.Id == taskId);

            if(currentTask == null)
            {
                Console.WriteLine($"There isn't a taks with id {taskId}");

                return false;
            }
            else
            {
                currentTask.Id = newId;
                currentTask.Title = newTitle;
                currentTask.Description = newDesc;
                currentTask.IsComplete = newIscomplete;

                return true;
            }
        }

        public bool DeteleTask(TaskList list, int taskId)
        {
            Task currentTask = list.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (currentTask == null)
            {
                Console.WriteLine($"There isn't a taks with id {taskId}");

                return false;
            }
            else
            {
                list.Tasks.Remove(currentTask);
                Console.WriteLine($"You deleted task {currentTask.Title}");

                return true;
            }
            
        }
    }
}
