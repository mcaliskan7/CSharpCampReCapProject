using Core.Utilities.Results.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IEntityService<User>
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByEmail(string email);
    }
}