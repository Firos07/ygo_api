
using YgoData.DataCommand.Interface;
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryUser.Interface;
using YgoModel;

namespace YgoLogic.FactoryUser.Class
{
    public class User : IUser
    {
        private readonly IUserCommand _userCommand;
        private readonly IUserQuery _userQuery;

        public User(IUserCommand userCommand, IUserQuery userQuery)
        {
            _userCommand = userCommand;
            _userQuery = userQuery;
        }

        public int UserInsert(UserDto user)
        {
            return _userCommand.InsertUserData(user);
        }

        public UserDto UserDataByIdFireBaseGet(string IdFireBase)
        {
            return _userQuery.UserDataGet(IdFireBase);
        }
    }
}
