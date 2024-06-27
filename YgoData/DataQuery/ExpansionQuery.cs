
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;
using YgoModel;

namespace YgoData.DataQuery.Interface
{
    public class ExpansionQuery : IExpansionQuery
    {
        private readonly IConfiguration _configuration;
        public ExpansionQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ExpansionDto> DataByCodeGetList(string CodeCard)
        {
            var expansionList = new List<ExpansionDto>();
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
                    command.CommandText = "[dbo].[USP_ExpansionByCodeCard_GETL]";
                    command.Parameters.Add(new SqlParameter("@Code", CodeCard));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var newItem = new ExpansionDto()
                            {
                                IdExpansion = reader["idexpansion"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idexpansion"].ToString(), CultureInfo.CurrentCulture),
                                Code = reader["Code"] == DBNull.Value ? string.Empty : reader["Code"].ToString(),
                                Name = reader["Name"] == DBNull.Value ? string.Empty : reader["Name"].ToString(),
                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? null : reader.GetDateTime(reader.GetOrdinal("ReleaseDate"))
                            };
                            expansionList.Add(newItem);
                        }
                    }
                    command.Parameters.Clear();

                    //--------------------------------------------------------------------------------------------------------------//

                    expansionList.ForEach(expansion => {
                        var rarityList = new List<RarityDto>();
                        command.CommandText = "[dbo].[USP_RarityByExpansionAndCard_GETL]";
                        command.Parameters.Add(new SqlParameter("@Code", CodeCard));
                        command.Parameters.Add(new SqlParameter("@IdExpansion", expansion.IdExpansion));

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
                        expansion.RarityList = rarityList;
                    });

                    //--------------------------------------------------------------------------------------------------------------//

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    var algo = ex.Message;
                    transaction.Rollback();
                    throw;
                }
            }
            return expansionList;
        }
    }
}
