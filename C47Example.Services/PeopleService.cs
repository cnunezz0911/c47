using C47Example.Models.Domain;
using C47Example.Models.Request;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace C47Example.Services
{
    public class PeopleService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int Insert(PeopleAddRequest model)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string cmdText = "Carlos_Nunez_Insert";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter parm = new SqlParameter();
                    parm.ParameterName = "@Id";
                    parm.SqlDbType = System.Data.SqlDbType.Int;
                    parm.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(parm);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@DOB", model.DOB);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return result;
        }

        public List<People> GetAll()
        {
            List<People> result = new List<People>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string cmdText = "Carlos_Nunez_SelectAll";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        People model = new People();
                        int index = 0;
                        model.Id = reader.GetInt32(index++);
                        model.FirstName = reader.GetString(index++);

                        if (!reader.IsDBNull(index))

                            model.MiddleInitial = reader.GetString(index++)[0];
                        else
                            index++;
                        model.LastName = reader.GetString(index++);
                        model.DOB = reader.GetDateTime(index++);
                        model.CreatedDate = reader.GetDateTime(index++);
                        model.ModifiedDate = reader.GetDateTime(index++);
                        model.ModifiedBy = reader.GetString(index++);
                        result.Add(model);
                    }
                    conn.Close();
                }
            }

            return result;
        }
    }
}
