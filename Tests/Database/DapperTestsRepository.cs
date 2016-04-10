using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Tests.Database
{
    public class DapperTestsRepository : ITestStatsRepository
    {
       
            public void Add(Run run)
            {
                using (IDbConnection connection = new SqlConnection(Constants.Address))
                {
                    const string query =
                    @"INSERT INTO dbo.TestRuns (StartTime, RunningTime, Passed, Failed, Uncompleted, TotalNumberOfTests)
                                                VALUES (@StartTime, @RunningTime, @Passed, @Failed, @Uncompleted, @TotalNumberOfTests);
                                                SELECT CAST(SCOPE_IDENTITY() as int)";
                    
                    var id = connection.Query<int>(query, run).Single();
                    foreach (var test in run.Executions)
                    {
                        InsertTest(test, id, connection);
                    }
                }
            }

        public void InsertTest(TestExecution test, int id, IDbConnection connection)
        {
            const string query =
                @"INSERT INTO dbo.TestExecutions (RunID, Name, Fixture, Result, Description, ExecutionTime)
                                              VALUES (@RunID, @Name, @Fixture, @Result, @Description, @ExecutionTime)";
            connection.Execute(query, new {RunID = id, test.Name, test.Fixture, test.Result, test.Description, test.ExecutionTime});
        }
    }
}
