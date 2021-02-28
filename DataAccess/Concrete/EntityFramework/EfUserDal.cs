using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CRSContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CRSContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}