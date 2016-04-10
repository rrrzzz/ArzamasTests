using System.Data.Entity;

namespace Tests.Database
{
    public class TestStatsContext : DbContext
    {
        public TestStatsContext() : base(Constants.Address)
        {
        }

        public DbSet<Run> TestRuns { get; set; }
        public DbSet<TestExecution> TestExecutions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Run>().ToTable("TestRuns");
        }
    }
}
