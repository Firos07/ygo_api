
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using YgoData.DataQuery.Interface;
using YgoModel;

namespace YgoData.DataQuery
{
    public class CardQuery : ICardQuery
    {
        private readonly IConfiguration _configuration;

        public CardQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CardDto> AllCardGetList()
        {
            var cardList = new List<CardDto>();
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
                    command.CommandText = "[dbo].[USP_AllCard_GETL]";
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var newItem = new CardDto()
                            {
                                Code = reader["CodeCard"] == DBNull.Value ? string.Empty : reader["CodeCard"].ToString(),
                                Name = reader["NameCard"] == DBNull.Value ? string.Empty : reader["NameCard"].ToString(),
                                CardType = reader["NameTypeCard"] == DBNull.Value ? string.Empty : reader["NameTypeCard"].ToString(),
                                SubCardType = reader["NameSubTypeCard"] == DBNull.Value ? string.Empty : reader["NameSubTypeCard"].ToString()
                            };
                            cardList.Add(newItem);
                        }
                    }
                    command.Parameters.Clear();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    var algo = ex.Message;
                    transaction.Rollback();
                    throw;
                }
            }
            return cardList;
        }
    }
}
