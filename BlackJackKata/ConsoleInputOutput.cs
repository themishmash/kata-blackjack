using System;

namespace kata_blackjack
{
    internal class ConsoleInputOutput : IInputOutput
    {
        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}