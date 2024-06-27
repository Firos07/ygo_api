using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;
using YgoData.DataCommand.Interface;
using YgoModel;

namespace YgoData.DataCommand
{
    public class CardInCollectionCommand : ICardInCollectionCommand
    {
        private readonly IConfiguration _configuration;

        public CardInCollectionCommand(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int InsertCardInCollection(CardInCollectionDto cardInCollection, int IdCollection)
        {
            int IdCardInCollection = 0;
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
                    command.CommandText = "[dbo].[USP_CardInCollection_INS]";
                    command.Parameters.Add(new SqlParameter("IdCollection", IdCollection));
                    command.Parameters.Add(new SqlParameter("IdCardByExpansion", cardInCollection.IdCardInCollection));
                    command.Parameters.Add(new SqlParameter("Quantity", cardInCollection.Quantity));
                    command.Parameters.Add(new SqlParameter("Conditions", cardInCollection.Conditions));

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdCardInCollection = reader["IdCardInCollection"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCardInCollection"].ToString(), CultureInfo.CurrentCulture);
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
            return IdCardInCollection;
        }
    }
}
