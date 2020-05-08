using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Application.Accounts.Queries.GetUsersList
{
    public class UserLookupModel
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public bool IsSuperUser { get; private set; }

        public bool IsOwner { get; private set; }
        public UserLookupModel(int id, string login, bool isSuperUser, bool isOwner)
        {
            Id = id;
            Login = login;
            IsSuperUser = isSuperUser;
            IsOwner = isOwner;
        }
    }
}
