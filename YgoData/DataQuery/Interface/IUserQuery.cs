
using YgoModel;

namespace YgoData.DataQuery.Interface
{
    public interface IUserQuery
    {
        public List<UserDto> CardsInExchangeByAllUsers();
        public UserDto UserDataGet(string IdFireBase);
    }
}
