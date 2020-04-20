namespace kata_blackjack
{
    public interface IInputOutput
    {
        string AskQuestion(string question);
        
        void Output(string message);

    }
}