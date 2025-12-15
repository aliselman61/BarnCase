using System;
using System.Data;
using System.Data.SqlClient;

namespace BarnCase.DataAccess
{
    public class UserMoneyRepository : IUserMoneyRepository
    {
        public decimal GetMoney(string username)
        {
            using (SqlConnection conn = DbConfig.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
             "SELECT Money FROM UserMoney WHERE Username=@u", conn))
            {
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 40).Value = username;

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    SetMoney(username, 500m);
                    return 500m;
                }

                return (decimal)result;
            }
        }
        public void SetMoney(string username, decimal money)
        {
            using (SqlConnection conn = DbConfig.GetConnection())
            {
                conn.Open(); 

                using (SqlCommand checkCmd = new SqlCommand(
                 "SELECT COUNT(*) FROM UserMoney WHERE Username=@u", conn))
                {
                    checkCmd.Parameters.Add("@u", SqlDbType.NVarChar, 40).Value = username;
                    int count = (int)checkCmd.ExecuteScalar();

                    string sql;
                    if (count == 0)
                        sql = "INSERT INTO UserMoney(Username,Money) VALUES(@u,@m)";
                    else
                        sql = "UPDATE UserMoney SET Money=@m WHERE Username=@u";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@u", SqlDbType.NVarChar, 40).Value = username;  
                        cmd.Parameters.Add("@m", SqlDbType.Decimal).Value = money;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
