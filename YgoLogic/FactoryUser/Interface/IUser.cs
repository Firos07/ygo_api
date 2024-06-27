
using YgoModel;

namespace YgoLogic.FactoryUser.Interface
{
    public interface IUser
    {
        public int UserInsert(UserDto user);
        public UserDto UserDataByIdFireBaseGet(string IdFireBase);
    }
}
