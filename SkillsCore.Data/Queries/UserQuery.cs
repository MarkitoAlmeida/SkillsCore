using Microsoft.Data.SqlClient;
using SkillsCore.Application.Interfaces.Queries;

namespace SkillsCore.Data.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly SqlConnection sqlConnection;

        //public UserQuery() =>
        //    sqlConnection = new SqlConnection(HelperConnectionString.connectionString);
    }
}
