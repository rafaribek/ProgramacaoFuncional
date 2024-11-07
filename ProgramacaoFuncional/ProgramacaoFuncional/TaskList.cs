using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoFuncional
{

    //Classe que gerencia a lista de tarefas(TaskItem) d um user
    public class TaskList
    {
        public List<TaskItem> Tasks { get; }

       public TaskList(List<TaskItem> tasks)
        {
            
            Tasks = new List<TaskItem>(tasks);
        }

        public TaskList AddTask(TaskItem task) 
        {
            //Criamos uma nova lista
            //copiando as tarefas já existentes
            var newTasks = new List<TaskItem>(Tasks);

            //Adicionei uma nova tarefa a lista
            newTasks.Add(task);

            //Retoenar nova incstancia de tasklist
            //com a lista atualizada
            return new TaskList(newTasks);

        }

        public TaskList UpdateTask(TaskItem updatedTask)
        {
            //nova lista copiando tarefas exxistentes
            var newTasks = new List<TaskItem>(Tasks);

            for (int i = 0; i < newTasks.Count; i++)
            {
                if(newTasks[i].Id == updatedTask.Id)
                {
                    //Aqui encpontramos a tarefa antiga
                    //agora substituimos pela nova
                    newTasks[i] = updatedTask;
                    break;
                }
            }

            return new TaskList(newTasks);
        }

    }
}
