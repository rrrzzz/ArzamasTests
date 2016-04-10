using System;

namespace Tests
{
    public class TestExecution
    {
        public int ID { get; set; }
        public int RunID { get; set; }
        public string Fixture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public TimeSpan ExecutionTime { get; set; }

    }
}