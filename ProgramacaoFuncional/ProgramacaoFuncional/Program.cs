using System;
using System.Threading;

namespace ProgramacaoFuncional
{
    class Program
    {
        static void Main(string[] args)
        {
            //**1. Criação das tarefas iniciais**
            var task1 = new TaskItem(1, "Aprender Programação", false);
            var task2 = new TaskItem(2, "Consertar ar condicionado", false);

            //**2 Criação da lista inicial de tarefas
            var initialTaskList = new TaskList(
                new List<TaskItem> { task1, task2 }
              );

            //**3 Criar o usuario
            var user = new User(1, "João", initialTaskList);

            //Atualização do "Concluido" de uma tarefa"
            //Marcar a primeira tarefa como concluida
            //e o método vai me retornar um novo TaskItem
            var completedTask = task1.MarkAsCompleted();

            //**5 atualizção da lista de tarefas
            var updateTaskList = user.TaskList.UpdateTask(completedTask);

            //**6 Atualização do usuário
            user = user.UpdateTaskList(updateTaskList);

            //**7 Obtenção de tarefas pendentes
            var pendingTasks = TaskService.GetPendingTasks(user.TaskList);

            //**8 Definir uma ação(Action) de processamento
            //- Exibir uma mensagem indicando que a tarefa está sendo processada
            //- Simular um tempo de execução

            Action<TaskItem> processAction = task =>
            {
                //Exobor a descriçao
                Console.WriteLine($"Processando tarefa: {task.Description}");

                //Simular a operação que leva 1 seg.
                Thread.Sleep(1000);
            };

            //**9 Processamento das tarefas em paralelo
            TaskService.ProcessTasksInParallel(pendingTasks, processAction);

            //**10 Composição funções
            //Primeira função: Obter as tarefas pendentes
            //Segunda função: processar as tarefas em paralelo
            //O resultado é uma nova função que, dada uma tasklist,
            //obtem as tarefas penentes e as processa

            var processPendingTasks = Utilities.Compose<TaskList, List<TaskItem>>(
                TaskService.GetPendingTasks,
                tasks => TaskService.ProcessTasksInParallel(tasks, processAction)
                );

            //**11 Usar a função composta
            processPendingTasks(user.TaskList);

            //**12 Uso de delegates para notificações
            Func<User, string, string> notifyDelegate =NotificationService.Notify;

            //**13 Geração da mensagem para notificação
            //utilizando o delegate
            string notificationMessage = notifyDelegate(user, "Você tem" +
                " tarefas pendentes!");

            //**14 Realização do efeito colateral da função pura
            Console.WriteLine(notificationMessage);

            //**15 Finaliza
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadLine();
        }
    }
}
