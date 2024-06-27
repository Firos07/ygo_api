
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;
using YgoData.DataCommand.Interface;
using YgoModel;

namespace YgoData.DataCommand
{
    public class UserCommand : IUserCommand
    {
        private readonly IConfiguration _configuration;

        public UserCommand(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int InsertUserData(UserDto user)
        {
            int IdUser = 0;
            using (SqlConnection connection = new(_configuration.GetConnectionString("OltpFleetMerchantConnection")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    command.CommandText = "[dbo].[USP_User_INS]";
                    command.Parameters.Add(new SqlParameter("IdFireBase", user.IdFireBase));
                    command.Parameters.Add(new SqlParameter("Name", user.Name));
                    command.Parameters.Add(new SqlParameter("Email", user.Email));

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdUser = reader["IdUser"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdUser"].ToString(), CultureInfo.CurrentCulture);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    var algo = ex.Message;
                    transaction.Rollback();
                    throw;
                }
            }
            return IdUser;
        }
    }
}
