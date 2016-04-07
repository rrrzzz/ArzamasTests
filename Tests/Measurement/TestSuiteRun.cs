using System;
using System.Collections.Generic;

namespace Tests
{
    public class TestSuiteRun
    {
        public List<TestExecution> Executions { get; set; }
        public DateTime StarTimeUtc { get; }
        public TimeSpan TotalTime { get; private set; }
        public int Passed { get; private set; }
        public int Failed { get; private set; } 
        public int Uncompleted { get; private set; }
        public int TotalTests => Executions.Count;

        public TestSuiteRun(DateTime utcNow)
        {
            StarTimeUtc = utcNow;
            Executions = new List<TestExecution>();
        }

        public void Add(TestExecution execution)
        {
            Executions.Add(execution);
            TotalTime += execution.TimeResult;
            switch (execution.TestResult)
            {
                case "Failed":
                    Failed++;
                    break;
                case "Passed":
                    Passed++;
                    break;
                default:
                    Uncompleted++;
                    break;
            }
        }
    }
}