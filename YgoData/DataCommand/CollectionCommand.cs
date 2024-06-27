
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;
using YgoData.DataCommand.Interface;
using YgoModel;

namespace YgoData.DataCommand
{
    public class CollectionCommand : ICollectionCommand
    {
        private readonly IConfiguration _configuration;

        public CollectionCommand(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int InsertCollection(CollectionDto collection, int IdUser)
        {
            int IdCollection = 0;
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
                    command.CommandText = "[dbo].[USP_Collection_INS]";
                    command.Parameters.Add(new SqlParameter("IdUser", IdUser));
                    command.Parameters.Add(new SqlParameter("IdCollectionType", (int) collection.CollectionType));
                    command.Parameters.Add(new SqlParameter("Name", collection.Name));
                    

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdCollection = reader["IdCollection"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCollection"].ToString(), CultureInfo.CurrentCulture);
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
            return IdCollection;
        }
    }
}
