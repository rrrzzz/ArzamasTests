using System;

namespace Tests
{
    public class TestExecution
    {
        public string Fixture { get; }
        public string Name { get; }
        public string Comment { get; }
        public string Result { get; }
        public TimeSpan ExecutionTime { get; }

        public TestExecution(string fixture, string name, string result, string comment, TimeSpan executionTime)
        {
            Fixture = fixture; 
            Name = name;
            Result = result;
            Comment = comment;
            ExecutionTime = executionTime;
        }
    }
}