
using YgoLogic.FactoryUser.Interface;
using YgoModel;

namespace YgoLogic.FactoryUser.Abstract
{
    public abstract class AUserCreator
    {
        public abstract IUser FactoryMethod();

        public int UserInsert(UserDto user)
        {
            var product = FactoryMethod();
            var result = product.UserInsert(user);

            return result;
        }

        public UserDto UserDataByIdFireBaseGet(string idFireBase)
        {
            var product = FactoryMethod();
            var result = product.UserDataByIdFireBaseGet(idFireBase);

            return result;
        }
    }
}
