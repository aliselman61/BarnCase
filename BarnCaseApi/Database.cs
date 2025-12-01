using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BarnCaseApi
{
    public static class Database
    {
        private static string connectionString =
            @"Data Source=ALI;Initial Catalog=BarnCaseDB;Integrated Security=True";



        public static decimal GetUserMoney(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Money FROM UserMoney WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        SetUserMoney(username, 500);
                        return 500;
                    }

                    return Convert.ToDecimal(result);
                }
            }
        }

        public static void SetUserMoney(string username, decimal money)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM UserMoney WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(check, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    int exists = (int)cmd.ExecuteScalar();

                    string query;

                    if (exists == 0)
                        query = "INSERT INTO UserMoney (Username, Money) VALUES (@Username, @Money)";
                    else
                        query = "UPDATE UserMoney SET Money = @Money WHERE Username = @Username";

                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@Username", username);
                        cmd2.Parameters.AddWithValue("@Money", money);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
        }



        public static List<FarmManagement.SimpleAnimal> LoadAnimals(string username)
        {
            List<FarmManagement.SimpleAnimal> list = new List<FarmManagement.SimpleAnimal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Animals WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new FarmManagement.SimpleAnimal
                            {
                                Id = (Guid)rdr["Id"],
                                Name = rdr["Name"].ToString(),
                                Type = rdr["Type"].ToString(),
                                Age = Convert.ToInt32(rdr["Age"]),
                                Gender = rdr["Gender"].ToString(),
                                Price = Convert.ToDecimal(rdr["Price"]),
                                DeathCause = rdr["DeathCause"].ToString()
                            });
                        }
                    }
                }
            }

            return list;
        }

        public static void SaveAnimal(string username, FarmManagement.SimpleAnimal a)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    @"INSERT INTO Animals (Id, Username, Name, Type, Age, Gender, Price, DeathCause)
                      VALUES (@Id, @Username, @Name, @Type, @Age, @Gender, @Price, @DeathCause)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", a.Id);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Name", a.Name);
                    cmd.Parameters.AddWithValue("@Type", a.Type);
                    cmd.Parameters.AddWithValue("@Age", a.Age);
                    cmd.Parameters.AddWithValue("@Gender", a.Gender);
                    cmd.Parameters.AddWithValue("@Price", a.Price);
                    cmd.Parameters.AddWithValue("@DeathCause", a.DeathCause);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAnimal(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Animals WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateAnimal(FarmManagement.SimpleAnimal a, string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    @"UPDATE Animals SET
                        Name = @Name,
                        Type = @Type,
                        Age = @Age,
                        Gender = @Gender,
                        Price = @Price,
                        DeathCause = @DeathCause
                      WHERE Id = @Id AND Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", a.Id);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Name", a.Name);
                    cmd.Parameters.AddWithValue("@Type", a.Type);
                    cmd.Parameters.AddWithValue("@Age", a.Age);
                    cmd.Parameters.AddWithValue("@Gender", a.Gender);
                    cmd.Parameters.AddWithValue("@Price", a.Price);
                    cmd.Parameters.AddWithValue("@DeathCause", a.DeathCause);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
