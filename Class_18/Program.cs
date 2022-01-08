using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine(); // считываем строку 

            Console.WriteLine(Check(str));// что бы проверить строку вызываем метод Check, сразу выводим на консоль 
            Console.ReadKey();

        }

        static bool Check(string str)
        {// создаем метод кт будет сразу возвращать true или false
            Stack<char> stack = new Stack<char>(); // элемент стека char(т.е. символ)
            Dictionary<char, char> sk = new Dictionary<char, char> // заводим словарь, char - будет являться ключом (например открытая скобка) , в ячейке-значение тоже будет лежать char т.е. соответствующая закрытая скобка
            {
                {'(', ')' },  // '(' - это ключ,   ')'  - это значение
                {'{', '}' },
                {'[', ']' },
            };
            foreach (char c in str) //перебираем всю строку посимвольно, используем foreach т.к. ничего не будем менять
            {
                if (c == '(' || c == '{' || c == '[') // проверяем если символ является каким то (например открытая скобка), то нужно поместить соответствующую другую скобку (напримпер закрытую) в стек
                    stack.Push(sk[c]);
                if (c==')' || c=='}' || c==']')
                {
                    if (stack.Count==0 || stack.Pop()!=c) // если стек равен 0, т.е. пустой или не равен с(т.е. извлеченный символ не соответствует тому что там должен находиться ) значит прерываем этот метод 
                    {
                        return false; // и возвращаем false в static bool Check
                    }
            
                }
            }
            // вышли из цикла foreach и теперь проверям не остался ли в стеке какой то элемент 
            if (stack.Count == 0)
                return true;
            else
                return false;
        }
    }
}
