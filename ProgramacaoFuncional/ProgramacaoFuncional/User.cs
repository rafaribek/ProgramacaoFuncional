using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoFuncional
{
    public class User
    {
        public int Id { get; }
        public string Name { get;}

        public TaskList TaskList { get; }

        public User(int id, string name, TaskList taskList) 
        {
            Id = id;
            Name = name;
            TaskList = taskList;
        }

        public User UpdateTaskList(TaskList newTaskList)
        {
            return new User(Id, Name, newTaskList);
        }
    }
}
