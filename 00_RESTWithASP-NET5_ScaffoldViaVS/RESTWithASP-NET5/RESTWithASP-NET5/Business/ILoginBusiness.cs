﻿using RESTWithASP_NET5.Data.VO;

namespace RESTWithASP_NET5.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}