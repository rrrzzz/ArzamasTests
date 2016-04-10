using System.Data.Entity;

namespace Tests.Database
{
    public class TestStatsContext : DbContext
    {
        private const string Address = @"Server=АРИНА-VAIO\SQLEXPRESS;Initial Catalog=TestStats;Integrated Security=True";

        public TestStatsContext() : base(Address)
        {
        }

        public DbSet<TestSuiteRun> TestRuns { get; set; }
        public DbSet<TestExecution> TestExecutions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestSuiteRun>().ToTable("TestRuns");
            modelBuilder.Entity<TestExecution>().Property(x => x.TestSuiteRunID).HasColumnName("RunID");
        }
    }
}
