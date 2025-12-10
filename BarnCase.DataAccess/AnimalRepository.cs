using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BarnCase.Entities;

namespace BarnCase.DataAccess
{
    public class AnimalRepository : IAnimalRepository
    {
        public List<Animal> GetAnimals(string username)
        {
            var list = new List<Animal>();

            using (SqlConnection conn = DbConfig.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Animals WHERE Username=@u", conn))
            {
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 40).Value = username;

                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var a = new Animal();
                        a.Id = (Guid)rdr["Id"];
                        a.Username = (string)rdr["Username"];
                        a.Name = (string)rdr["Name"];
                        a.Type = (string)rdr["Type"];
                        a.Age = (int)rdr["Age"];
                        a.Gender = (string)rdr["Gender"];
                        a.Price = (decimal)rdr["Price"];
                        a.DeathCause = rdr["DeathCause"] as string;

                        list.Add(a);
                    }
                }
            }

            return list;
        }

        public void AddAnimal(Animal a)
        {
            using (SqlConnection conn = DbConfig.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Animals(Id,Username,Name,Type,Age,Gender,Price,DeathCause)
                  VALUES(@id,@u,@n,@t,@age,@g,@p,@d)", conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = a.Id;
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 40).Value = a.Username;
                cmd.Parameters.Add("@n", SqlDbType.NVarChar, 40).Value = a.Name;
                cmd.Parameters.Add("@t", SqlDbType.NVarChar, 20).Value = a.Type;
                cmd.Parameters.Add("@age", SqlDbType.Int).Value = a.Age;
                cmd.Parameters.Add("@g", SqlDbType.NVarChar, 10).Value = a.Gender;
                cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = a.Price;
                cmd.Parameters.Add("@d", SqlDbType.NVarChar, 200).Value =
                    (object)a.DeathCause ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAnimal(Animal a)
        {
            using (SqlConnection conn = DbConfig.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Animals SET
                    Name=@n, Type=@t, Age=@age, Gender=@g, Price=@p, DeathCause=@d
                  WHERE Id=@id", conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = a.Id;
                cmd.Parameters.Add("@n", SqlDbType.NVarChar, 40).Value = a.Name;
                cmd.Parameters.Add("@t", SqlDbType.NVarChar, 20).Value = a.Type;
                cmd.Parameters.Add("@age", SqlDbType.Int).Value = a.Age;
                cmd.Parameters.Add("@g", SqlDbType.NVarChar, 10).Value = a.Gender;
                cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = a.Price;
                cmd.Parameters.Add("@d", SqlDbType.NVarChar, 200).Value =
                    (object)a.DeathCause ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveAnimal(Guid id)
        {
            using (SqlConnection conn = DbConfig.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Animals WHERE Id=@id", conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
