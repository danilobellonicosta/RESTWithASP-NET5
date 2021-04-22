using RESTWithASP_NET5.Data.VO;
using RESTWithASP_NET5.Models;

namespace RESTWithASP_NET5.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}
