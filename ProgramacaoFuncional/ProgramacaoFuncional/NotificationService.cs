using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoFuncional
{
    //Classe responsável por gerar mensagens de notificação
    public class NotificationService
    {
        //Por quê esta é uma função pura?
        //1- sem efeitos colaterais: não modifica nenhum estado externo ou realiza operãções de I/O

        //2- Deterministica: Para os mesmos parametros de entrada
        //ela sempre retorna o mesmo resultado

        //3- Independente de estado externo: não depende de variáveis ou estados
        //que possam mudar fora de seu escopo
        public static string Notify(User user, string message)
        {
            return $"Notificação para {user.Name}: {message}";
        }
    }
}
