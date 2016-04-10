using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Tests.Database
{
    public class TestsRepository : ITestStatsRepository
    {
       public void Add(TestSuiteRun run)
        {
            using (var dbContext = new TestStatsContext())
            {
                dbContext.TestRuns.Add(run);
                dbContext.SaveChanges();
            }
        }
    }
}
