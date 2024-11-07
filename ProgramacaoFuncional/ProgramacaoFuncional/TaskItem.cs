using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoFuncional
{
    public class TaskItem
    {
        //Propriedades somente para leitura
        //garantir imutabilidade
        public int Id { get;}
        public string Description { get;}

        public bool IsCompleted { get;}

        public TaskItem(int id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }

        //Método que retorna uma nova instância da tarefa com o status atualizado
        //sem alterar o objeto ja existente
        public TaskItem MarkAsCompleted()
        {
            return new TaskItem(Id, Description, true);
        }
    }
}
