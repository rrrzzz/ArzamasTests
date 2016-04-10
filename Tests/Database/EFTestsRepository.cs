namespace Tests.Database
{
    public class EfTestsRepository : ITestStatsRepository
    {
       public void Add(Run run)
        {
            using (var dbContext = new TestStatsContext())
            {
                dbContext.TestRuns.Add(run);
                dbContext.SaveChanges();
            }
        }
    }
}
