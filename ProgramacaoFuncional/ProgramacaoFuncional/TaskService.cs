using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoFuncional
{
    //contem funcoes para manipular tarefas
    public class TaskService
    {
        //Funcao pura que filtra tarefas incompletas

        public static List<TaskItem> GetPendingTasks(TaskList taskList) 
        {
            var pendingTasks = new List<TaskItem>();

            foreach(var task in taskList.Tasks)
            {
                if (!task.IsCompleted)
                {
                    pendingTasks.Add(task);
                }
            }
            return pendingTasks;    
        }

        //função de alto nível que recebe outra como parâmetro(delegate)

        public static void ProcessTasks(List<TaskItem> tasks, Action<TaskItem> processAction)
        {
            foreach (var task in tasks)
            {
                processAction(task);
            }
        }

        //Action<T1> representa um metodo que aceita um parametro do tipo "T1" e não retorna valor.

        //Func<TInput1, TInput2, TResult>

        public static void ProcessTasksInParallel(List<TaskItem> tasks , Action<TaskItem> processAction)
        {
            //Criar uma lista para armazenar as threads
            var threads = new List<Thread>();

            //thread é uma tarefa que o programa pode executar de forma independente
            //um programa pode ter várias threads
            //cada uma realizando uma tarefa diferente

            foreach (var task in tasks)
            {
                var currentTask = task;
                
                //Criar uma nova thread que execute a
                //ação do processamento

                var thread = new Thread(() => processAction(currentTask));
                threads.Add(thread);

                //iniciar a thread assegurando que a execução
                //vai começar assim que possivel
                thread.Start();
            }

            //Aguardar toda as threads terminarem sua execução.
            foreach (var thread in threads)
            {
                //O método Join bloqueia a execução do programa
                //até que a thread especifica termine sua operação
                thread.Join();
            }

        }
    }
}
