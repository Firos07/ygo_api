
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;
using YgoData.DataQuery.Interface;
using YgoModel;

namespace YgoData.DataQuery
{
    public class RarityQuery : IDataQuery<RarityDto>
    {
        private readonly IConfiguration _configuration;

        public RarityQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<RarityDto> DataByCodeGetList(string CodeCard, int IdExtension)
        {
            var rarityList = new List<RarityDto>();
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
                    command.CommandText = "[dbo].[USP_RarityByExtensionAndCard_GETL]";
                    command.Parameters.Add(new SqlParameter("@Code", CodeCard));
                    command.Parameters.Add(new SqlParameter("@IdExpansion", IdExtension));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var newItem = new RarityDto()
                            {
                                IdRarity = reader["IdRarity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdRarity"].ToString(), CultureInfo.CurrentCulture),
                                Name = reader["Name"] == DBNull.Value ? string.Empty : reader["Name"].ToString()
                            };
                            rarityList.Add(newItem);
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
            return rarityList;
        }

        public List<RarityDto> DataByCodeGetList(string Code)
        {
            throw new NotImplementedException();
        }
    }
}
