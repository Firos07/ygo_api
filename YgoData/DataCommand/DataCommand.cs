
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;
using YgoModel;

namespace YgoData.DataCommand
{
    public class DataCommand : IDataCommand
    {
        private readonly IConfiguration _configuration;
        public DataCommand(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public int InsertCardData(CardDto card)
        {
            int IdTypeCard = 0;
            int IdSubTypeCard = 0;
            int IdCard = 0;
            int IdExpansion = 0;
            int IdRarity = 0;

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
                    //--------------------------------------------------------------------------------------------------------------//
                    command.CommandText = "[dbo].[USP_TypeCard_INS_GET]";
                    command.Parameters.Add(new SqlParameter("Name", card.CardType));
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdTypeCard = reader["IdTypeCard"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdTypeCard"].ToString(), CultureInfo.CurrentCulture);
                        }
                    }
                    command.Parameters.Clear();

                    //--------------------------------------------------------------------------------------------------------------//

                    command.CommandText = "[dbo].[USP_SubTypeCard_INS_GET]";
                    command.Parameters.Add(new SqlParameter("Name", card.SubCardType));
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdSubTypeCard = reader["IdSubTypeCard"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSubTypeCard"].ToString(), CultureInfo.CurrentCulture);
                        }
                    }
                    command.Parameters.Clear();

                    //--------------------------------------------------------------------------------------------------------------//
                    command.CommandText = "[dbo].[USP_Card_INS_GET]";
                    command.Parameters.Add(new SqlParameter("IdTypeCard", IdTypeCard));
                    command.Parameters.Add(new SqlParameter("IdSubTypeCard", IdSubTypeCard));
                    command.Parameters.Add(new SqlParameter("Code", card.Code));
                    command.Parameters.Add(new SqlParameter("Name", card.Name));
                    command.Parameters.Add(new SqlParameter("Url_Image", card.Url_Image));
                    command.Parameters.Add(new SqlParameter("Text", card.Text));
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdCard = reader["IdCard"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCard"].ToString(), CultureInfo.CurrentCulture);
                        }
                    }
                    command.Parameters.Clear();

                    //--------------------------------------------------------------------------------------------------------------//

                    card.ExpansionList?.ForEach(expansion =>
                    {
                        var splitCodeExpansion = expansion.Code?.Split("-");
                        command.CommandText = "[dbo].[USP_Expansion_INS_GET]";
                        command.Parameters.Add(new SqlParameter("Code", splitCodeExpansion?.First()));
                        command.Parameters.Add(new SqlParameter("Name", expansion.Name));
                        command.Parameters.Add(new SqlParameter("ReleaseDate", expansion.ReleaseDate));
                        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                IdExpansion = reader["IdExpansion"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdExpansion"].ToString(), CultureInfo.CurrentCulture);
                            }
                        }
                        command.Parameters.Clear();

                        //--------------------------------------------------------------------------------------------------------------//

                        expansion.RarityList?.ForEach(rarity =>
                        {
                            command.CommandText = "[dbo].[USP_Rarity_INS_GET]";
                            command.Parameters.Add(new SqlParameter("Name", rarity.Name));
                            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                            {
                                if (reader.Read())
                                {
                                    IdRarity = reader["IdRarity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdRarity"].ToString(), CultureInfo.CurrentCulture);
                                }
                            }
                            command.Parameters.Clear();

                            //--------------------------------------------------------------------------------------------------------------//

                            command.CommandText = "[dbo].[USP_CardByExpansion_INS]";
                            command.Parameters.Add(new SqlParameter("IdCard", IdCard));
                            command.Parameters.Add(new SqlParameter("IdExpansion", IdExpansion));
                            command.Parameters.Add(new SqlParameter("IdRarity", IdRarity));
                            command.Parameters.Add(new SqlParameter("NumberExpansion", splitCodeExpansion?.Length == 2 ? splitCodeExpansion?.Last() : string.Empty));
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        });
                    });

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    var algo = ex.Message;
                    transaction.Rollback();
                    throw;
                }
            }
            return IdCard;
        }



        public int InsertMonsterData(MonsterCardDto monster)
        {
            int IdMonsterCard = 0;
            int IdCard = InsertCardData(monster);
            int IdMonsterAttribute = 0;
            int IdInnerMonsterType = 0;

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
                    //--------------------------------------------------------------------------------------------------------------//
                    command.CommandText = "[dbo].[USP_MonsterAttribute_INS_GET]";
                    command.Parameters.Add(new SqlParameter("Name", monster.MonsterAttribute));
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdMonsterAttribute = reader["IdMonsterAttribute"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdMonsterAttribute"].ToString(), CultureInfo.CurrentCulture);
                        }
                    }
                    command.Parameters.Clear();

                    //--------------------------------------------------------------------------------------------------------------//

                    command.CommandText = "[dbo].[USP_InnerMonsterType_INS_GET]";
                    command.Parameters.Add(new SqlParameter("Name", monster.InnerMonsterType));
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdInnerMonsterType = reader["IdInnerMonsterType"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdInnerMonsterType"].ToString(), CultureInfo.CurrentCulture);
                        }
                    }
                    command.Parameters.Clear();

                    //--------------------------------------------------------------------------------------------------------------//
                    command.CommandText = "[dbo].[USP_MonsterCard_INS_GET]";
                    command.Parameters.Add(new SqlParameter("IdCard", IdCard));
                    command.Parameters.Add(new SqlParameter("IdMonsterAttribute", IdMonsterAttribute));
                    command.Parameters.Add(new SqlParameter("IdInnerMonsterType", IdInnerMonsterType));
                    command.Parameters.Add(new SqlParameter("Level_Rank_Rating", monster.Level_Rank_Rating));
                    command.Parameters.Add(new SqlParameter("Atk", monster.Atk));
                    command.Parameters.Add(new SqlParameter("Def", monster.Def));
                    command.Parameters.Add(new SqlParameter("IsEffect", monster.IsEffect));
                    command.Parameters.Add(new SqlParameter("IsTuner", monster.IsTuner));
                    command.Parameters.Add(new SqlParameter("IsGemini", monster.IsGemini));
                    command.Parameters.Add(new SqlParameter("IsUnion", monster.IsUnion));
                    command.Parameters.Add(new SqlParameter("IsToon", monster.IsToon));
                    command.Parameters.Add(new SqlParameter("IsFlip", monster.IsFlip));

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdMonsterCard = reader["IdMonsterCard"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdMonsterCard"].ToString(), CultureInfo.CurrentCulture);
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
            return IdMonsterCard;
        }


        public int InsertPendulumData(PendulumCardDto pendulum)
        {

            int IdMonsterCard = InsertMonsterData(pendulum);
            int IdPendulumAdditionalData = 0;

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
                    //--------------------------------------------------------------------------------------------------------------//
                    command.CommandText = "[dbo].[USP_PendulumAdditionalData_INS_GET]";
                    command.Parameters.Add(new SqlParameter("@IdMonsterCard", IdMonsterCard));
                    command.Parameters.Add(new SqlParameter("@PendulumScale", pendulum.PendulumScale));
                    command.Parameters.Add(new SqlParameter("@Pendulumtext", pendulum.PendulumText));

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            IdPendulumAdditionalData = reader["IdPendulumAdditionalData"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdPendulumAdditionalData"].ToString(), CultureInfo.CurrentCulture);
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
            return IdPendulumAdditionalData;
        }
    }
}