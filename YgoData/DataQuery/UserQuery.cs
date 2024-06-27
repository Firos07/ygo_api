
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;
using YgoData.DataQuery.Interface;
using YgoModel;


namespace YgoData.DataQuery
{
    public class UserQuery : IUserQuery
    {
        private readonly IConfiguration _configuration;

        public UserQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UserDto> CardsInExchangeByAllUsers() 
        {
            var userDataList = new List<UserDto>();

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
                    command.CommandText = "[dbo].[USP_CardsInExchange_GETL]";
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var newItem = new UserDto()
                            {
                                IdUser = reader["IdUSer"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdUSer"].ToString(), CultureInfo.CurrentCulture),
                                CollectionList = new List<CollectionDto> { new CollectionDto() { 
                                    IdCollection = reader["IdCollection"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCollection"].ToString(), CultureInfo.CurrentCulture),
                                    Name = reader["NameCollection"] == DBNull.Value ? string.Empty : reader["NameCollection"].ToString(),
                                    CardInCollectionList = new List<CardInCollectionDto>{ new CardInCollectionDto() {
                                        Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Quantity"].ToString(), CultureInfo.CurrentCulture),
                                        Conditions = reader["Conditions"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Conditions"].ToString(), CultureInfo.CurrentCulture),
                                        Card = new CardDto(){ 
                                            IdCard = reader["IdCard"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCard"].ToString(), CultureInfo.CurrentCulture),
                                            Name = reader["NameCard"] == DBNull.Value ? string.Empty : reader["NameCard"].ToString(),
                                            Url_Image = reader["ImgCard"] == DBNull.Value ? string.Empty : reader["ImgCard"].ToString(),
                                            ExpansionList = new List<ExpansionDto>{ new ExpansionDto() { 
                                                Code = reader["CodeExpansion"] == DBNull.Value ? string.Empty : reader["CodeExpansion"].ToString(),
                                                Name = reader["NameExpansion"] == DBNull.Value ? string.Empty : reader["NameExpansion"].ToString(),
                                                RarityList = new List<RarityDto>{ new RarityDto() { 
                                                    IdRarity = reader["IdRarity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdRarity"].ToString(), CultureInfo.CurrentCulture),
                                                    Name = reader["NameRarity"] == DBNull.Value ? string.Empty : reader["NameRarity"].ToString(),
                                                                } 
                                                            }
                                                        }
                                                    }
                                                }
                                            } 
                                        },
                                    } 
                                },
                                
                            };
                            userDataList.Add(newItem);
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
            return userDataList;
        }


        public UserDto UserDataGet(string IdFireBase)
        {
            var user = new UserDto();
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
                    command.CommandText = "[dbo].[USP_UserByFirebaseId_GETI]";
                    command.Parameters.Add(new SqlParameter("IdFireBase", IdFireBase));
                    

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            user.IdUser = reader["IdUser"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdUser"].ToString(), CultureInfo.CurrentCulture);
                            user.Name = reader["NameCard"] == DBNull.Value ? string.Empty : reader["NameCard"].ToString();
                            user.Name = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString();
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
            return user;
        }
    }
}
