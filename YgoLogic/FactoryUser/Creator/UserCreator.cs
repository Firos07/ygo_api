
using YgoData.DataCommand.Interface;
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryUser.Abstract;
using YgoLogic.FactoryUser.Class;
using YgoLogic.FactoryUser.Interface;

namespace YgoLogic.FactoryUser.Creator
{
    public class UserCreator : AUserCreator
    {
        private readonly IUserCommand _userCommand;
        private readonly IUserQuery _userQuery;

        public UserCreator(IUserCommand userCommand, IUserQuery userQuery)
        {
            _userCommand = userCommand;
            _userQuery = userQuery;
        }

        public override IUser FactoryMethod()
        {
            return new User(_userCommand, _userQuery);
        }
    }
}
