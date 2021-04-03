using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindeksService:IEntityService<Findeks>
    {
        IDataResult<Findeks> GetByCustomerId(int customerId);

        IDataResult<Findeks> CalculateFindeksScore(Findeks findeks);
    }
}
