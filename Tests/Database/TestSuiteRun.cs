using System;
using System.Collections.Generic;

namespace Tests
{
    public class TestSuiteRun
    {
        public int ID { get; set; }
        public List<TestExecution> Executions { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan RunningTime { get;  set; }
        public int Passed { get;  set; }
        public int Failed { get;  set; } 
        public int Uncompleted { get;  set; }
        public int TotalNumberOfTests { get; set; }

        public TestSuiteRun()
        {
           Executions = new List<TestExecution>();
        }

        public void Add(TestExecution execution)
        {
            Executions.Add(execution);
            TotalNumberOfTests++;
            RunningTime += execution.ExecutionTime;
            switch (execution.Result)
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