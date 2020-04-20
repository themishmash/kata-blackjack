using kata_blackjack;

namespace blackjackTests
{
    public class TestInputOutYesResponse : IInputOutput
    {
        public string AskQuestion(string question)
        {
            return "y";
        }

        public void Output(string message)
        {
            return;
        }
    }
}