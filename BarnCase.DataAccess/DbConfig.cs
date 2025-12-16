using System.Data.SqlClient;

namespace BarnCase.DataAccess
{
   public static class DbConfig
   {
      private const string ConnectionString =
       @"Data Source=ALI;Initial Catalog=BarnCaseDB;Integrated Security=True";

      public static SqlConnection GetConnection()
      {
        return new SqlConnection(ConnectionString);
      }
   }
}
