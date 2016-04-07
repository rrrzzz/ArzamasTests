using System;

namespace Tests
{
    public class TestExecution
    {
        public string Fixture { get; }
        public string TestName { get; }
        public string TestComment { get; }
        public string TestResult { get; }
        public TimeSpan TimeResult { get; }

        public TestExecution(string fixture, string testName, string testResult, string testComment, TimeSpan timeResult)
        {
            Fixture = fixture; 
            TestName = testName;
            TestResult = testResult;
            TestComment = testComment;
            TimeResult = timeResult;
        }
    }
}