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

        //this is using the other constructor to get this work
        // public TestResponder(string response):this(new []
        // {
        //     response,
        //     response,
        //     response
        // })
        // {
        //     _testResponses.Enqueue(response);
        //     //_response = response;
        // }
        
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
            // return "1";
            return _testResponses.Dequeue();
        }

        
        public void Output(string message)
        {
            return;
        }

        // private string Response()
        // {
        //     if (_response == "1")
        //     {
        //         return "1";
        //     }
        //     return "0";
        // }

        
    }
}