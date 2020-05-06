using System;
using System.Collections;
using System.Collections.Generic;
using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class TestResponder : IInputOutput
    {
       
        //private readonly string _response;  //if public use {get;} getter which is called auto property
        private readonly Queue <string>_testResponses = new Queue<string>();
        
        
        public TestResponder(string response)
        {
            _testResponses.Enqueue(response);
            //_response = response;
        }
        

        public TestResponder(IEnumerable<string> testResponse)
        {
            foreach (var response in testResponse)
            {
                _testResponses.Enqueue(response);
            }
        }
        

        public string AskQuestion(string question)
        {
            return _testResponses.Dequeue();
        }

        
        public void Output(string message)
        {
            return;
        }


    }
}