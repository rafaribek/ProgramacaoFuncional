using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoFuncional
{
    //Classe com funções auxiliares
    public class Utilities
    {
        //Func<T, R> = o método Compose retornará uma função que recebe algo
        //do tipo "T" e retorna algo do tipo "R"

        //<T, U, R>
        //T : Típo de entrada da função resultante
        //e da primeira função da composição

        //U : É um tipo intermediário que é a saída da primeira função
        //e a entrada da segunda função

        //R : Tipo de saída da função resultante
        //e da segunda função na composição
        public static Func<T, R> Compose<T, U, R> (Func<T, U> f, Func< U, R> g)
        {
            //EX: Func<int, double> f = x => x * 2.5;
            //EX: Func<double, string> g = y => $"O resultado é {y}";
            return x => g(f(x));//Expressão Lambda
        }

        //sobrecarga da função compose para funções que retornam void(Action)
        public static Action<T> Compose<T, U>(Func<T, U> f, Action<U> g) 
        {
            return x => g(f(x));
        }

        //Funções de alta ordem (recebem e/ou retornam métodos)
        //Composição de funções (Combinação de 2)
        //Imutabilidade: Nao ha alteração de estado
        //Abstração genérica: Usa de parametros de tipo´para criar funcoes independentes
        //Expressão lambda: Definição concisa de funções anonimas
        //Encapsulamento: Agrupamento de Lógica Reutilizável
    }
}
